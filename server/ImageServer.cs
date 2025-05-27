using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace rec_rewild_classic.server
{
    class ImageServer
    {
        private HttpListener listener = new HttpListener();
        public ImageServer()
        {
            try
            {
                Console.WriteLine("[ImageServer.cs] has started.");
                new Thread(new ThreadStart(this.StartListen)).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occurred while Listening :" + ex.ToString());
            }
        }
        private void StartListen()
        {
            this.listener.Prefixes.Add("http://localhost:20182/");
            byte[] notfound = new WebClient().DownloadData("https://raw.githubusercontent.com/wiiboi69/Rec_rewild/master/Update/notfoundimage.jpg");
            this.listener.Start();
            for (; ; )
            {

                Console.WriteLine("[ImageServer.cs] is listening.");
                HttpListenerContext context = this.listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string rawUrl = request.RawUrl;
                string text;
                bool flag = false;
                byte[] i = File.ReadAllBytes("SaveData/profileimage.png");
                using (StreamReader streamReader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    text = streamReader.ReadToEnd();
                }
                if (rawUrl.StartsWith("/alt/") || rawUrl.StartsWith("/" + File.ReadAllText("SaveData/Profile/username.txt")))
                {
                    i = File.ReadAllBytes("SaveData/profileimage.png");
                    flag = true;
                    response.ContentType = "image/png";
                }
                else if (rawUrl.StartsWith("//room/"))
                {
                    string temp = rawUrl.Substring("//room/".Length);
                    if (File.Exists($"SaveData/Rooms/cdn/{temp}"))
                    {
                        i = File.ReadAllBytes($"SaveData/Rooms/cdn/{temp}");
                    }
                    //else
                    //    i = new WebClient().DownloadData("https://cdn.rec.net" + rawUrl.Remove(0, 1));
                    flag = true;

                }
                else if (rawUrl.StartsWith("//video/"))
                {
                    string temp = rawUrl.Substring("//video".Length);
                    try
                    {
                        if (File.Exists($"SaveData/Rooms/cdn/{temp}"))
                        {
                            i = File.ReadAllBytes($"SaveData/Rooms/cdn/{temp}");
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"[ImageServer.cs] {temp} video not found. trying to download from github");
                        i = new WebClient().DownloadData("https://raw.githubusercontent.com/wiiboi69/Rec_rewild_server_data/main/CDN/video" + rawUrl);
                    }
                    flag = true;
                }
                Console.WriteLine("Image Requested: " + rawUrl);
                Console.WriteLine("Image Data: " + text);
                response.StatusCode = (int)HttpStatusCode.OK;
                byte[] bytes = i;
                if (!flag)
                {
                    bytes = new Byte[4];
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                Console.WriteLine("Image Response: " + response.StatusCode);
                response.ContentLength64 = bytes.LongLength;
                Stream outputStream = response.OutputStream;
                outputStream.Write(bytes, 0, bytes.Length);
                outputStream.Flush();
            }
        }
    }
}
