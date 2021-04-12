using LoggerLibrary;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace PlaylistCreatorLibrary
{
    public static class Authorization
    {
        public static string AuthorizeApp()
        {
            string state = StringGenerator.RandomString(16);

            string client_id = "7b7216ecd0b545668ca684314847782c";
            string scope = "user-read-private%20user-read-email";
            string redirect_url = "https://localhost:44356/api/AccessToken";

            var dict = new Dictionary<string, string>();
            dict.Add("response_type", "code");
            dict.Add("client_id", client_id);
            dict.Add("scope", scope);
            dict.Add("redirect_uri", HttpUtility.UrlEncode(redirect_url));
            dict.Add("state", state);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient client = new HttpClient();

            var requestUri = QueryHelpers.AddQueryString("https://accounts.spotify.com/authorize", dict);
            
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,requestUri);


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
