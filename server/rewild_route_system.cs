using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace rec_rewild_classic.server
{
    public class rewild_route_system
    {
        public static object ParseJsonBody(string body, Type targetType)
        {
            return JsonConvert.DeserializeObject(body, targetType); // Deserialize into the specified type
        }

        public static string ParseRequestBody(HttpListenerRequest request)
        {
            using var reader = new StreamReader(request.InputStream, request.ContentEncoding);
            return reader.ReadToEnd(); // Reads raw data from the body
        }

        public static Dictionary<string, string> ParseFormData(string body)
        {
            var formData = new Dictionary<string, string>();
            var parsedQuery = HttpUtility.ParseQueryString(body);
            foreach (var key in parsedQuery.AllKeys)
            {
                formData[key] = parsedQuery[key];
            }
            return formData;
        }

        public enum url_level
        {
            high = 300,
            medium = 200,
            low = 100,
            none = 0
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        public class RouteAttribute : Attribute
        {
            public string Path { get; }
            public bool IsRawRegex { get; } // Flag for raw regex mode
            public url_level Priority { get; } // php shit
            public RouteAttribute(string path, bool isRawRegex = false, url_level priority = url_level.low)
            {
                Path = path;
                IsRawRegex = isRawRegex;
                Priority = priority;
            }
        }
    }
}
