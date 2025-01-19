using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using api;

namespace server
{
	internal class ImageServer
	{
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
				
				Console.WriteLine("{ImageServer.cs] is listening.");
				HttpListenerContext context = this.listener.GetContext();
				HttpListenerRequest request = context.Request;
				HttpListenerResponse response = context.Response;
				string rawUrl = request.RawUrl;
				string text;
				bool flag = false;
				byte[] i = File.ReadAllBytes("SaveData\\profileimage.png"); 
				using (StreamReader streamReader = new StreamReader(request.InputStream, request.ContentEncoding))
				{
					text = streamReader.ReadToEnd();
				}
				if (rawUrl.StartsWith("/alt/") || rawUrl.StartsWith("/" + File.ReadAllText("SaveData\\Profile\\username.txt")))
                {
					i = File.ReadAllBytes("SaveData\\profileimage.png");
					flag = true;

                }
				else if (rawUrl.StartsWith("//room/"))
                {
					string temp = rawUrl.Substring("//room/".Length);
                    if (File.Exists($"SaveData\\Rooms\\cdn\\{temp}"))
					{
						i = File.ReadAllBytes($"SaveData\\Rooms\\cdn\\{temp}");
					}
					else
						i = new WebClient().DownloadData("https://cdn.rec.net" + rawUrl.Remove(0, 1));
					flag = true;

                }
                else if (rawUrl.StartsWith("//data/"))
				{
                    string temp = rawUrl.Substring("//data/".Length);
                    if (File.Exists($"SaveData\\Rooms\\cdn\\{temp}"))
                    {
                        i = File.ReadAllBytes($"SaveData\\Rooms\\cdn\\{temp}");
                    }
                    else
                        i = new WebClient().DownloadData("https://cdn.rec.net" + rawUrl.Remove(0, 1));
                    flag = true;

                }
                else if (rawUrl.StartsWith("//asset/"))
                {
                    string temp = rawUrl.Substring("//asset/".Length);
                    if (File.Exists($"SaveData\\Rooms\\cdn\\{temp}"))
                    {
                        i = File.ReadAllBytes($"SaveData\\Rooms\\cdn\\{temp}");
                        flag = true;
                    }
                }
                else if (rawUrl.StartsWith("/rewild_studio/Img/"))
                {
                    string temp = rawUrl.Substring("/rewild_studio/Img/".Length);
                    i = new WebClient().DownloadData($"https://raw.githubusercontent.com/wiiboi69/Rec_rewild_server_data/refs/heads/main/AdditionalData/Textures/{temp}");
					flag = true;
                }
                else if (rawUrl.StartsWith("SaveData/images/"))
                {
                    string temp = rawUrl.Substring("SaveData/images/".Length);
                    if (File.Exists($"SaveData\\images\\{temp}"))
                    {
                        i = File.ReadAllBytes($"SaveData\\images\\{temp}");
                        flag = true;
                    }
                }
                else if (rawUrl.StartsWith("/Profile") || rawUrl.StartsWith("/profile"))
                {
                    try
                    {
                        i = File.ReadAllBytes("SaveData\\profile.png");
                    }
                    catch
                    { }
                    flag = true;

                }
                else if (rawUrl.StartsWith("//video/"))
                {
                    rawUrl = rawUrl.Substring("//video".Length);
                    try
                    {
                        i = new WebClient().DownloadData("https://cdn.rec.net" + rawUrl.Remove(0, 1));
                    }
                    catch
                    {
                        Console.WriteLine($"[ImageServer.cs] {rawUrl} video not found on cdn.rec.net. trying to download from github");
                        i = new WebClient().DownloadData("https://raw.githubusercontent.com/wiiboi69/Rec_rewild_server_data/main/CDN/video" + rawUrl);
                    }
                    flag = true;
                }
                /*
                else
                {
					try
                    {
						i = new WebClient().DownloadData("https://img.rec.net" + rawUrl);
					}
					catch
                    {
						Console.WriteLine("[ImageServer.cs] Image not found on img.rec.net.");
						i = notfound;
                        flag = true;

                    }
                }
				*/

                Console.WriteLine("Image Requested: " + rawUrl);
				Console.WriteLine("Image Data: " + text);
				Console.WriteLine("Image Response: ");
                response.StatusCode = (int)HttpStatusCode.OK;
                byte[] bytes = i;
				if (!flag)
				{
					bytes = new Byte[4];
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                response.ContentLength64 = bytes.LongLength;
				Stream outputStream = response.OutputStream;
				outputStream.Write(bytes, 0, bytes.Length);
                //Thread.Sleep(1);
                //outputStream.Close();
                //this.listener.Stop();
                outputStream.Flush();
            }
        }
		public static string VersionCheckResponse = "{\"ValidVersion\":true}";
		public static string BlankResponse = "";

		private HttpListener listener = new HttpListener();
	}
}
