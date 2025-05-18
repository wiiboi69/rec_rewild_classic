using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using api;
using api2018;
using api2017;
using Newtonsoft.Json;
using rewild_room_sesh;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Rec_rewild.api;
using start;
using ws;

namespace server
{
    internal class build_detector_API
    {
        public build_detector_API()
        {
            try
            {
                Console.WriteLine("[APIServer2016.cs] has started.");
                new Thread(new ThreadStart(this.StartListen)).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occurred while Listening :" + ex.ToString());
            }
        }
        private void StartListen()
        {
            try
            {
                this.listener.Prefixes.Add("http://localhost:2034/");
                this.listener.Start();
                Console.WriteLine("[] is listening.");

                while (true)
                {
                    HttpListenerContext context = this.listener.GetContext();
                    ThreadPool.QueueUserWorkItem(o => HandleRequest(context));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                File.WriteAllText("crashdump.txt", Convert.ToString(ex));
                this.listener.Close();
                new APIServer2016();
            }
        }

        static Dictionary<string, string> keyValueStore = new Dictionary<string, string>();

        private void HandleRequest(HttpListenerContext context)
        {
            try
            {
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string rawUrl = request.RawUrl;
                string Url = "";
                bool image = false;
                byte[] imagebyte = null;
                if (rawUrl.StartsWith("/api/"))
                {
                    Url = rawUrl.Remove(0, 5);
                }
                string text;
                string s = "";
                byte[] array;
                string contentType = request.ContentType;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    context.Request.InputStream.CopyTo(memoryStream);
                    array = memoryStream.ToArray();
                    text = Encoding.ASCII.GetString(array);
                }
                if (!(Url == ""))
                {
                    Console.WriteLine("API Requested: " + Url);
                }
                else
                {
                    Console.WriteLine("API Requested (rawUrl): " + rawUrl);
                }
                if (request.HttpMethod == "POST")
                {
                    if (contentType == "application/x-www-form-urlencoded")
                    {
                        keyValueStore = ParseKeyValuePairs(text);
                    }
                    else if (contentType == "application/json")
                    {

                    }
                }
                if (rawUrl.StartsWith("/api/version"))
                {
                    if (rawUrl.Length > 22)
                    {
                        this.DetectVersion(rawUrl.Remove(0, 23));
                    }
                    else if (rawUrl.Contains('2'))
                    {
                        this.DetectVersion("2017");
                    }
                    else
                    {
                        this.DetectVersion("2016/2017");
                    }
                    s = APIServer_Base.VersionCheckResponse;
                }
                Console.WriteLine("API Response: " + s);
                byte[] bytes = null;
                if (image == true)
                {
                    bytes = imagebyte;
                }
                else
                {
                    bytes = Encoding.UTF8.GetBytes(s);
                }
                response.ContentLength64 = (long)bytes.Length;
                Stream outputStream = response.OutputStream;
                outputStream.Write(bytes, 0, bytes.Length);
                outputStream.Flush();
            }
            catch (Exception ex4)
            {
                Console.WriteLine(ex4);
                File.WriteAllText("crashdump.txt", Convert.ToString(ex4));
            }
        }

        public void DetectVersion(string Version)
        {
            if (Version.StartsWith("20181") || Version.StartsWith("201809"))
            {
                if (detector_version != "20182")
                {
                    Console.Title = "rec_rewild_classic - Late 2018";
                    Program.version = "2018";
                    start.Program.api_port = int.Parse(start.Program.version + "0");
                    Console.Clear();
                    Console.WriteLine("Version Detected: Late 2018");
                    new ImageServer();
                    this.listener.Close();
                    new APIServer2018();
                    new WebSocketHTTP();
                    new Late2018WebSock();
                }
            }
            if (Version.StartsWith("2019"))
            {
                if (detector_version != "2019")
                {
                    Console.Title = "rec_rewild_classic - 2019 Beta";
                    Program.version = "2019";
                    start.Program.api_port = int.Parse(start.Program.version + "0");
                    Console.Clear();
                    Console.WriteLine("Version Detected: 2019");
                    new ImageServer();
                    this.listener.Close();
                    new APIServer2019();
                    new WebSocketHTTP();
                    new Late2018WebSock();
                }
            }
            else if (Version.StartsWith("2018"))
            {
                if (detector_version != "2018")
                {
                    Console.Title = "rec_rewild_classic - Mid 2018";
                    Program.version = "2018";
                    start.Program.api_port = int.Parse(start.Program.version + "0");
                    Console.Clear();
                    Console.WriteLine("Version Detected: Mid 2018");
                    new ImageServer();
                    this.listener.Close();
                    new APIServer2018();
                    new WebSocket();
                }
            }
            else if (Version.StartsWith("2017"))
            {
                if (detector_version != "2017")
                {
                    Console.Title = "rec_rewild_classic - 2017";
                    Program.version = "2017";
                    Console.Clear();
                    Console.WriteLine("Version Detected - 2017");
                    this.listener.Close();
                    new APIServer2017();
                    new WebSocket();
                }
            }
            else if (Version == "2016/2017")
            {
                if (detector_version != "2016/2017")
                {
                    Console.Title = "rec_rewild_classic - 2016";
                    Program.version = "2016";
                    Console.Clear();
                    Console.WriteLine("Version Detected: - 2016");
                    this.listener.Close();
                    new APIServer2016();
                    new WebSocket();
                }
            }
            else if (detector_version != "20182")
            {
                Console.Title = "rec_rewild_classic - unknown version";
                Program.version = "2018";
                start.Program.api_port = int.Parse(start.Program.version + "0");
                Console.Clear();
                Console.WriteLine("unknown version detected: you might have issues");
                new ImageServer();
                this.listener.Close();
                new APIServer2018();
                new WebSocketHTTP();
                new Late2018WebSock();
            }
        }

        static T Get_value<T>(Dictionary<string, string> data, string key)
        {
            foreach (var item in data)
            {
                if (item.Key == key)
                {
                    return (T)Convert.ChangeType(item.Value, typeof(T));
                }
            }
            return default(T);
        }
        static Dictionary<string, string> ParseKeyValuePairs(string data)
        {
            var keyValuePairs = new Dictionary<string, string>();
            var entries = data.Split('&');
            foreach (var entry in entries)
            {
                var pair = entry.Split('=');
                if (pair.Length == 2)
                {
                    string key = pair[0].Trim();
                    string value = pair[1].Trim();
                    keyValuePairs[key] = value;
                }
            }
            return keyValuePairs;
        }

        public static string BlankResponse = "";
        public static string BracketResponse = "[]";
        public static string detector_version = "";
        public static string version_data = "";


        private HttpListener listener = new HttpListener();
    }
}
