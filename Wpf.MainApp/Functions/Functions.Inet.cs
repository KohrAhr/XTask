using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.GridView.Functions
{
    public class InetFunctions
    {
        public async Task<string> GetRequest(string Url)
        {
            string result = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                result = await client.GetStringAsync(Url);
            }

            //HttpWebRequest myRequest = WebRequest.CreateHttp(Url);
            //myRequest.Method = "GET";

            //using (WebResponse response = myRequest.GetResponse())
            //{
            //    using (Stream streamResponse = response.GetResponseStream())
            //    {
            //        using (StreamReader streamRead = new StreamReader(streamResponse))
            //        {
            //            result = streamRead.ReadToEnd();
            //            streamRead.Close();
            //        }
            //        streamResponse.Close();
            //    }
            //    // Release the HttpWebResponse
            //    response.Close();
            //}

            return result;
        }

        public async Task<string> PostRequest(string Url, Dictionary<string, string> Data)
        {
            string result = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(Data);

                var response = await client.PostAsync(Url, content);

                var responseString = await response.Content.ReadAsStringAsync();

                result = await client.GetStringAsync(Url);
            }

            return result;
        }
    }
}
