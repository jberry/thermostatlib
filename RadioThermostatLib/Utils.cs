using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermostatLib
{
    public class Utils
    {


        public static string GetUrlContents(string url)
        {
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string result = sr.ReadToEnd();
            return result;
        }

        public static string HttpPost(string url,string parameters)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(parameters);

            System.Net.WebRequest req = (System.Net.WebRequest)System.Net.WebRequest.Create(url);
            req.ContentType = "application/json; charset=utf-8";
            req.Method = "POST";
            req.ContentLength = bytes.Length;
            System.IO.Stream stream = req.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();

            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string result = sr.ReadToEnd();
            return result;
        }


    }
}
