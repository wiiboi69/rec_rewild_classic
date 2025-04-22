using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace rec_rewild_classic.Program_menu
{
    class Rec_Net_Client
    {
        public static string Get_String(string url)
        {
            string data = string.Empty;
            HttpClient client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Version = new Version(2, 0),
            };
            client.DefaultRequestVersion = HttpVersion.Version20;
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/json,application/xml;q=0.9,*/*;q=0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            client.DefaultRequestHeaders.Add("Origin", "https://rec.net");
            client.DefaultRequestHeaders.Add("Referer", "https://rec.net/");
            var x = client.SendAsync(req).GetAwaiter().GetResult();
            x.EnsureSuccessStatusCode();
            StreamReader reader = new StreamReader(x.Content.ReadAsStream());
            data = reader.ReadToEnd();
            return data;
        }
        public static byte[] Get_Byte(string url)
        {
            byte[] data = Array.Empty<byte>();
            HttpClient client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Version = new Version(2, 0),
            };
            client.DefaultRequestVersion = HttpVersion.Version20;
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/json,application/xml,image/avif,image/webp,image/png,image/svg+xml,image/*;q=0.8,*/*;q=0.5");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            client.DefaultRequestHeaders.Add("Origin", "https://rec.net");
            client.DefaultRequestHeaders.Add("Referer", "https://rec.net/");
            var x = client.SendAsync(req).GetAwaiter().GetResult();
            x.EnsureSuccessStatusCode();
            data = x.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            return data;
        }
    }
}
