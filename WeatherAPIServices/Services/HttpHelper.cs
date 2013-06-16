using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WeatherAPIServices.Services
{
    public class HttpHelper
    {
    
        public static string DoHttpGet(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new Exception("url");

            String result = "";
            WebRequest request = WebRequest.Create(url);
            request.Method = "Get";
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                result = stream.ReadToEnd();
            }
            return result;
        }

        public static string DoHttpPost(string url, string postData = "")
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new Exception("url");

            String result = "";
            WebRequest request = WebRequest.Create(url);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            using (WebResponse response = request.GetResponse()) { 
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = reader.ReadToEnd();
            
            }
            return result;
        }
    }
}

