using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Threading;
using static rec_rewild_classic.server.rewild_route_system;
using rec_rewild_classic.api;
using System.IO;

namespace rec_rewild_classic.server.rewild_route
{
    class APIServer_system
    {
        public static APIServer_system APIServer;
        public APIServer_system()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:" + Program.api_port + "/");

            RegisterRoutes();

            new Thread(new ThreadStart(this.Start)).Start();
            
            Running = true;
        }
        public static bool Running = false;
        private readonly HttpListener _listener;
        public void RefreshApplicationState(object sender, FileSystemEventArgs e)
        {
            RegisterRoutes(true);
        }
        public static void reloadRegisterRoutes()
        {
            APIServer.RegisterRoutes(true);
        }

        #region server_handling

        private readonly List<(Regex RoutePattern, MethodInfo Handler, ParameterInfo[] Params, url_level Priority)> _routeHandlers = new();
        
        private void RegisterRoutes(bool reload = false)
        {
            if (reload)
            {
                Console.WriteLine("APIServer_system [DEBUG]: Reregistering all of the Route");
                _routeHandlers.Clear();
            }
            else
                Console.WriteLine("APIServer_system: Registering Route");

            foreach (var method in Assembly.GetExecutingAssembly().GetTypes()
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)))
            {
                var routeAttribute = method.GetCustomAttribute<RouteAttribute>();
                if (routeAttribute != null)
                {
                    var pattern = "";
                    if (routeAttribute.IsRawRegex)
                    {
                        // Use raw regex pattern directly
                        pattern = routeAttribute.Path;
                    }
                    else
                    {
                        pattern = "^" + Regex.Escape(routeAttribute.Path)
                            .Replace("\\*", ".*")      // Match any string for wildcards
                            .Replace("\\{", "(?<")     // Start named group
                            .Replace("}", ">[^/]+)")   // End named group
                            + "$";
                    }
                    var regex = new Regex(pattern, RegexOptions.Compiled);
                    var parameters = method.GetParameters();

                    // Store the route including ContentType metadata
                    _routeHandlers.Add((regex, method, parameters, routeAttribute.Priority));
                }
            }
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("APIServer_system: Listening...");
            while (true)
            {
                var context = _listener.GetContext();
                try
                {
                    ProcessRequest(context);
                }
                catch
                {
                }
            }
        }
        private void ProcessRequest(HttpListenerContext context)
        {
            var path = context.Request.Url.AbsolutePath;
            var query = context.Request.QueryString; // Retrieve query parameters
            string contentType = context.Request.ContentType;
            if (string.IsNullOrEmpty(contentType))
                contentType = "none";
            Console.WriteLine($"APIServer_system: Start of request.");

            Console.WriteLine($"APIServer_system: API Requested: {path}");
            Console.WriteLine($"APIServer_system: Content-Type: {contentType}");
            Console.WriteLine($"APIServer_system: Request-Method-Type: {context.Request.HttpMethod}");

            var response = context.Response;
            object response_data = null;

            var matchedRoutes = _routeHandlers.Where(r => r.RoutePattern.IsMatch(path))
                           .OrderByDescending(r => r.Priority) // Process highest priority first
                           .ToList();

            foreach (var (regex, method, parameters, routePriority) in _routeHandlers)
            {
                var match = regex.Match(path);
                if (match.Success)
                {
                    // Prepare arguments for handler
                    var args = new object[parameters.Length];
                    string body = "";
                    if (context.Request.ContentType == "application/json" || context.Request.ContentType == "application/x-www-form-urlencoded")
                    {
                        body = ParseRequestBody(context.Request);
                        Console.WriteLine($"APIServer_system: API Data: {body}");
                    }

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var paramType = parameters[i].ParameterType;

                        if (paramType == typeof(HttpListenerContext))
                        {
                            args[i] = context; // Pass the context directly
                        }
                        else if (paramType == typeof(Dictionary<string, string>) && context.Request.ContentType == "application/x-www-form-urlencoded")
                        {
                            // Parse form data
                            body = ParseRequestBody(context.Request);
                            args[i] = ParseFormData(body);
                        }
                        else if (context.Request.ContentType == "application/json")
                        {
                            // Parse JSON body and deserialize to expected type
                            args[i] = ParseJsonBody(body, paramType);
                        }
                        else if (paramType == typeof(string) && query != null && query[parameters[i].Name] != null)
                        {
                            // Retrieve query parameter value
                            args[i] = query[parameters[i].Name];
                        }
                        else if ((
                                paramType == typeof(int) ||
                                paramType == typeof(uint) ||
                                paramType == typeof(long) ||
                                paramType == typeof(ulong) ||
                                paramType == typeof(string)) && context.Request.ContentType == "application/x-www-form-urlencoded")
                        {
                            // Extract parameter value from form data
                            var formData = ParseFormData(body);
                            var paramName = parameters[i].Name;
                            args[i] = Convert.ChangeType(formData[paramName], paramType);
                        }
                        else if (
                                paramType == typeof(int) ||
                                paramType == typeof(uint) ||
                                paramType == typeof(long) ||
                                paramType == typeof(ulong) ||
                                paramType == typeof(string))
                        {
                            // Extract URL parameters
                            var paramName = parameters[i].Name;
                            if (match.Groups[paramName]?.Success == true)
                            {
                                args[i] = Convert.ChangeType(match.Groups[paramName].Value, paramType);
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException($"Unsupported parameter type: {paramType}");
                        }
                    }
                    try
                    {
                        // Invoke the handler
                        var result = method.Invoke(null, args);

                        // Handle void return types
                        if (method.ReturnType == typeof(void))
                        {

                            response.StatusCode = 200; // OK
                            response_data = "{ \"success\": \"true\" }";

                        }
                        else if (method.ReturnType == typeof(bool))
                        {
                            if ((bool)result == true)
                            {
                                response.StatusCode = 200; // OK
                                response_data = "{ \"success\": \"true\" }";
                            }
                            else
                                response_data = null;

                        }
                        else
                        {
                            response_data = result;
                        }
                    }
                    catch
                    {
                        response_data = null;
                    }
                    break;
                }
            }

            if (response_data == null)
            {
                response_data = HandleNotFound(context);
                response.StatusCode = 404;
            }

            WriteResponse(response, response_data);
        }

        private static void WriteResponse(HttpListenerResponse response, object response_data)
        {

            if (response_data is string responseString)
            {
                if (responseString.Length <= 0x1ff)
                {
                    Console.WriteLine($"APIServer_system: API json Response: " + responseString);
                }
                else
                {
                    Console.WriteLine($"APIServer_system: API json Response Length: " + responseString.Length);
                }
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentType = "application/json";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            else if (response_data is byte[] responseBytes)
            {
                Console.WriteLine($"APIServer_system: API byte[] Response Length: " + responseBytes.Length);

                response.ContentType = "application/octet-stream";
                response.ContentLength64 = responseBytes.Length;
                response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
            }
            else
            {
                throw new InvalidOperationException("Unsupported response data type.");
            }
            Console.WriteLine($"APIServer_system: End of request.\n");

            response.OutputStream.Close();
        }

        private string HandleNotFound(HttpListenerContext context)
        {
            return "{\"Success\": false, \"Error\": \"404 URL Not Found: " + context.Request.Url + "\"}";
        }
        #endregion

        public static string BlankResponse = "";
        public static string BracketResponse = "[]";
    }
}
