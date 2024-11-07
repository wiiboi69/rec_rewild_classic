﻿using System;
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
			for (; ; )
			{
				
				this.listener.Start();
				Console.WriteLine("{ImageServer.cs] is listening.");
				HttpListenerContext context = this.listener.GetContext();
				HttpListenerRequest request = context.Request;
				HttpListenerResponse response = context.Response;
				string rawUrl = request.RawUrl;
				string text;
				byte[] i = File.ReadAllBytes("SaveData\\profileimage.png"); 
				using (StreamReader streamReader = new StreamReader(request.InputStream, request.ContentEncoding))
				{
					text = streamReader.ReadToEnd();
				}
				if (rawUrl.StartsWith("/alt/"))
                {
					i = File.ReadAllBytes("SaveData\\profileimage.png");
				}
				else if (rawUrl.StartsWith("/" + File.ReadAllText("SaveData\\Profile\\username.txt")))
                {
					i = File.ReadAllBytes("SaveData\\profileimage.png");
				}
				else if (rawUrl.StartsWith("//room/"))
                {
					i = new WebClient().DownloadData("https://cdn.rec.net" + rawUrl.Remove(0, 1));
                }
				else if (rawUrl.StartsWith("//data/"))
				{
					i = new WebClient().DownloadData("https://cdn.rec.net" + rawUrl.Remove(0, 1));
				}
				else
                {
					try
                    {
						i = new WebClient().DownloadData("https://img.rec.net" + rawUrl);
					}
					catch
                    {
						Console.WriteLine("[ImageServer.cs] Image not found on img.rec.net.");
                    }
				}
				if (rawUrl.StartsWith("/CustomRoom.png"))
                {
					try
					{
						i = new WebClient().DownloadData("https://img.rec.net/" + File.ReadAllText("SaveData\\Rooms\\Downloaded\\imagename.txt"));
					}
					catch
					{
						Console.WriteLine("[ImageServer.cs] Image not found on img.rec.net.");
						i = new WebClient().DownloadData("https://img.rec.net/DefaultRoomImage.jpg");
					}
				}
				Console.WriteLine("Image Requested: " + rawUrl);
				Console.WriteLine("Image Data: " + text);
				Console.WriteLine("Image Response: ");
				byte[] bytes = i;
				response.ContentLength64 = (long)bytes.Length;
				Stream outputStream = response.OutputStream;
				outputStream.Write(bytes, 0, bytes.Length);
				Thread.Sleep(1);
				outputStream.Close();
				this.listener.Stop();
			}
		}
		public static string VersionCheckResponse = "{\"ValidVersion\":true}";
		public static string BlankResponse = "";

		private HttpListener listener = new HttpListener();
	}
}
