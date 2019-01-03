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
                FormUrlEncodedContent content = new FormUrlEncodedContent(Data);

                using (HttpResponseMessage response = await client.PostAsync(Url, content))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }

            return result;
        }
    }
}
