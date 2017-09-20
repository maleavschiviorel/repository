using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web ; 
using System.Net.Http ;
using System.Net;
namespace HttpRequest
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://usm.md/?page_id=2080");

            byte[] data1 = null;
        
            data1 = new byte[]{};// null;// ((byte[])PostData);
            request.Method = "GET";
            request.ContentType = "text/html; charset=UTF-8";

            request.KeepAlive = false;//;true
            //request.Connection = "Close";
            //request.ContentLength = 5906;
            request.Host = "usm.md";

            request.Headers["Request"] = "GET /usm.md/?page_id=2080 HTTP/1.1";
            request.Accept = "text/html, application/xhtml+xml, image/jxr, */*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:54.0) Gecko/20100101 Firefox/54.0";
            request.Headers["Accept-Encoding"] = "gzip, deflate";
            request.Referer = "http://usm.md/?page_id=2080";
            request.Headers["Cookie"] = @"_ym_uid=1503390601124752452; qtrans_cookie_test=qTranslate+Cookie+Test; _ym_isad=2";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            //using (var stream = request.GetRequestStream())
            //{
            //   // stream.Write(data1, 0, data1.Length);
            //}

            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                StreamReader sr = new StreamReader(response.GetResponseStream());
                StringBuilder responseString = new StringBuilder();
                int index = 0;
                while (!sr.EndOfStream)
                {
                    char[] rb = new char[256];
                    int n = sr.Read(rb, 0, 256);
                    string st = new string(rb);
                    responseString.Append(rb, 0, n);
                    index += n;
                }
           
                StreamWriter f = new StreamWriter("d:\\q.html",false,Encoding.UTF8   );
                //f.WriteLine(response.Headers);
                f.Write(responseString);
                f.Close();
                response.Close();

            }
            else
            {
            }

        }
    }
}
