using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Developers.WxOpen
{
   public class BaseRequestApi
    {
        /// <summary>
        /// Post方式调用api
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parame">字符串json参数</param>
        /// <returns></returns>
        public static string Post(string url, string parame)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";

            byte[] buffer = encoding.GetBytes(parame);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
        /// <summary>
        /// get方式调用api
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(string url)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }

        }
        /// <summary>
        /// 客户端访问api get方式
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> ClientGet(string url)
        {
            //创建Handler
            var hreder = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (var client = new HttpClient(hreder))
            {

                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）  
                return await response.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// 客户端访问api post方式
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<string> ClientGet(string url, string data)
        {
            string result = string.Empty;
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (var http = new HttpClient(handler))
            {
                var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                  {"", data}//键名必须为空  
                 });

                var response = await http.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
