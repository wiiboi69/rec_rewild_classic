using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

using System.Linq;
using System.Net;

using Newtonsoft.Json;
using System.Threading;

using static rec_rewild_classic.server.APIServer.rewild_route_system;
using api;
using System.IO;
using api2018;
using static api2018.logincached;
using server;

namespace rec_rewild_classic.server.APIServer.rewild_route
{
    class APIServer2018_new
    {
        public static APIServer2018_new APIServer;
        public APIServer2018_new()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:" + start.Program.api_port + "/");

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
        private readonly List<(Regex, MethodInfo, ParameterInfo[])> _routeHandlers = new();
        private void RegisterRoutes(bool reload = false)
        {
            if (reload)
            {
                Console.WriteLine("APIServer2018 [DEBUG]: Reregistering all of the Route");
                _routeHandlers.Clear();
            }
            else
                Console.WriteLine("APIServer2018: Registering Route");

            foreach (var method in Assembly.GetExecutingAssembly().GetTypes()
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)))
            {
                var routeAttribute = method.GetCustomAttribute<RouteAttribute>();
                if (routeAttribute != null)
                {
                    // Convert route path to regex with named groups for parameters
                    
                    var pattern = "^" + Regex.Escape(routeAttribute.Path)
                        .Replace("\\*", ".*")        // Match any string for wildcards
                        .Replace("\\{", "(?<")       // Start named group
                        .Replace("}", ">[^/]+)")   // End named group
                        + "$";
                    var regex = new Regex(pattern, RegexOptions.Compiled);

                    // Store the route method and metadata
                    var parameters = method.GetParameters();
                    _routeHandlers.Add((regex, method, parameters));
                }
            }
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("APIServer2018: Listening...");
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
            Console.WriteLine($"APIServer2018: Start of request.");

            Console.WriteLine($"APIServer2018: API Requested: {path}");
            Console.WriteLine($"APIServer2018: Content-Type: {contentType}");
            Console.WriteLine($"APIServer2018: Request-Method-Type: {context.Request.HttpMethod}");

            var response = context.Response;
            object response_data = null;

            foreach (var (regex, method, parameters) in _routeHandlers)
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
                        Console.WriteLine($"APIServer2018: API Data: {body}");
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
                    // Invoke the handler
                    var result = method.Invoke(null, args);

                    // Handle void return types
                    if (method.ReturnType == typeof(void))
                    {
                        response.StatusCode = 200; // OK
                        response_data = "{ \"success\": \"true\" }";
                    }
                    else
                    {
                        response_data = result;
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
                    Console.WriteLine($"APIServer2018: API json Response: " + responseString);
                }
                else
                {
                    Console.WriteLine($"APIServer2018: API json Response Length: " + responseString.Length);
                }
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentType = "application/json";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            else if (response_data is byte[] responseBytes)
            {
                Console.WriteLine($"APIServer2018: API byte[] Response Length: " + responseBytes.Length);

                response.ContentType = "application/octet-stream";
                response.ContentLength64 = responseBytes.Length;
                response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
            }
            else
            {
                throw new InvalidOperationException("Unsupported response data type.");
            }
            Console.WriteLine($"APIServer2018: End of request.\n");

            response.OutputStream.Close();
        }

        private string HandleNotFound(HttpListenerContext context)
        {
            return "{\"Success\": false, \"Error\": \"404 URL Not Found: " + context.Request.Url + "\"}";
        }
        #endregion

        public static string BlankResponse = "";
        public static string BracketResponse = "[]";

        public static string Version_build = "";

        [Route("/api/versioncheck/v3")]
        public static string GetVersion(string v)
        {
            Console.WriteLine($"APIServer2018: build version: " + v);
            Version_build = v;
            return "{\"ValidVersion\": true}";
        }

        [Route("/api/config/v2")]
        public static string Api_config()
        {
            return Config.GetDebugConfig();
        }

        [Route("/api/gameconfigs/v1/all")]
        public static string Api_gameconfigs()
        {
            return File.ReadAllText("SaveData/gameconfigs.txt");
        }

        [Route("//api/config/v1/room/all")]
        public static string Api_configs_room()
        {
            return new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/Rec_rewild_server_data/refs/heads/main/AdditionalData/studio/room/room_config.json");
        }
        
        [Route("//api/config/v1/room_data/all")]
        public static string Api_configs_room_data()
        {
            return new WebClient().DownloadString("https://raw.githubusercontent.com/wiiboi69/Rec_rewild_server_data/refs/heads/main/AdditionalData/studio/room/room_config_basic.json"); ;
        }

        [Route("/api/presence/v1/setplayertype")]
        public static string Api_presence_setplayertype()
        {
            return BracketResponse;
        }

        [Route("/api/relationships/v2/get")]
        public static string relationships_get()
        {
            return BracketResponse;
        }
        
        [Route("//api/chat/v2/myChats")]
        public static string chat_myChats(int mode, int count)
        {
            return BracketResponse;
        }
        public static string ModerationBlockDetails = "{\"ReportCategory\":0,\"Duration\":0,\"GameSessionId\":0,\"Message\":\"\"}";

        [Route("/api/PlayerReporting/v1/moderationBlockDetails")]
        public static string PlayerReporting_moderationBlockDetails()
        {
            return ModerationBlockDetails;
        }

        [Route("/api/relationships/v1/bulkignoreplatformusers")]
        public static string relationships_bulkignoreplatformusers()
        {
            return BracketResponse;
        }

        [Route("/api/messages/v2/get")]
        public static string messages_get()
        {
            return BracketResponse;
        }

        [Route("/api/playersubscriptions/v1/my")]
        public static string My_playersubscriptions()
        {
            return BracketResponse;
        }

        [Route("/api/config/v1/amplitude")]
        public static string amplitude_config()
        {
            return Amplitude.amplitude();
        }

        public static ulong CachedPlayerID = ulong.Parse(File.ReadAllText("SaveData\\Profile\\userid.txt"));

        [Route("/api/platformlogin/v1/getcachedlogins")]
        public static string Api_platformlogin_getcachedlogins(int Platform, ulong PlatformId)
        {
            Console.WriteLine($"APIServer2018: loading Platform " + Platform + " cachedlogin PlatformId: " + PlatformId + " with playerid: " + CachedPlayerID);

            return getcachedlogins.GetDebugLogin((ulong)CachedPlayerID, PlatformId);
        }

        [Route("/api/platformlogin/v1/logincached")]
        public static string Api_platformlogin_logincached(logincached_login login)
        {
            return logincached.loginCache(login.PlayerId, ulong.Parse(login.PlatformId));
        }
        /*
         /api/communityboard/v1/current
         
         */
    }
}
