using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SharedTools;


namespace MapleLib{
    public static class WebAPI{
        private static readonly Uri BaseUri = new Uri("https://api.nexon.net");

        public static async Task<string> GetAuthToken(string username, string password){
            string token = "";
            int uid = -1;
            string passport = "";
            String response = await WebAPI.performLogin(username, password);
            var jsonparse = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response);
            if (jsonparse.ContainsKey("access_token"))
            {
                token = jsonparse["access_token"];
                uid = (int)jsonparse["user_no"];
            }
            if (uid == -1 || token == "")
                Console.WriteLine("Failed to get token!");
            else
                passport = await WebAPI.requestPassport(token);
            return passport;
        }

        public static async Task<string> accountsAPIrequest(string path, RestSharp.Method method, object body)
        {
            RestClient client = new RestClient("https://accounts.nexon.net/");
            client.UserAgent = "NexonLauncher node-webkit/0.14.6 (Windows NT 10.0; WOW64) WebKit/537.36 (@c26c0312e940221c424c2730ef72be2c69ac1b67) nexon_client";
            RestRequest request = new RestRequest(path, method);
            request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
            request.AddHeader("Accept-Language", "en-US,en;q=0.8");
            request.AddJsonBody(body);
            var result = await client.ExecuteTaskAsync(request);
            return result.Content;
        }

        public static async Task<string> performLegacyLogin(string username, string password)
        {
            return await accountsAPIrequest("/account/login/legacy", Method.POST, new { id = username, password = password });
        }

        public static async Task<string> performMigration(string username, string password, string email)
        {
            return await accountsAPIrequest("/account/migrate", Method.POST, new { id = username, password = password, new_id = email });
        }

        public static async Task<string> performLogin(string username, string password)
        {
            return await accountsAPIrequest("/account/login/launcher", Method.POST, new { id = username, password = Hash.SHA512(password), auto_login = false, client_id = "7853644408", scope = "us.launcher.all", device_id = Hash.SHA256(username) });
        }


        public static async Task<string> nxAPIrequest(Uri uri, string token)
        {
            var filter = new HttpClientHandler();
            using (var c = new HttpClient(filter))
            {
                c.DefaultRequestHeaders.UserAgent.ParseAdd("NexonLauncher.nxl-17.10.03-150-6b2c4c1");
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(token)));
                filter.CookieContainer.Add(BaseUri, new Cookie("nxtk", token) { Domain = ".nexon.net", Path = "/" });

                string s = await c.GetStringAsync(uri).ConfigureAwait(false);
                string passport = "";
                var jsonparse = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(s);
                if (jsonparse.ContainsKey("passport"))
                    passport = jsonparse["passport"];
                else
                    Console.WriteLine("Failed to get passport!");
                Console.WriteLine(passport);
                return passport;
            }
        }

        public static async Task<string> requestPassport(string token)
        {
            return await nxAPIrequest(new Uri("https://api.nexon.io/users/me/passport"), token);
        }

        public static async Task<string> passportRefresh(string authserv, string passport)
        {
            var client = new RestClient("http://" + authserv + ".nexon.net/");
            client.UserAgent = "Python-urllib/2.7";
            var request = new RestRequest("/ajax/default.aspx?_vb=UpdateSession", Method.GET);
            request.AddParameter("NPPv2", passport, ParameterType.Cookie);
            var result = await client.ExecuteTaskAsync(request);
            return result.Content;
        }




    }
}