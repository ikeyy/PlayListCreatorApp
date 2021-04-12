using LoggerLibrary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace PlaylistCreatorLibrary
{
    public class AccessToken
    {
        public static string AccessTokenApp(string code)
        {
            string redirect_url = "https://localhost:44356/api/Authorization";

            var dict = new Dictionary<string, string>();
            dict.Add("grant_type", "code");
            dict.Add("code", code);
            dict.Add("redirect_uri", HttpUtility.UrlEncode(redirect_url));


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient client = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://accounts.spotify.com/api/token"),
                Headers = {
                            { HttpRequestHeader.ContentType.ToString(), "application/x-www-form-urlencoded"}
                            },
                Content = new FormUrlEncodedContent(dict)
            };


            var result = client.SendAsync(httpRequestMessage).Result;

            if (!result.IsSuccessStatusCode)
            {
                Logger.Error("[Response Error Handling]:" + result.StatusCode + "\r\n Content:\r\n" + result.Content.ReadAsStringAsync().Result);
            }

            string resultContent = result.Content.ReadAsStringAsync().Result;

            return resultContent;

        }
    }
}
