using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SKU_Generator.BackEnd
{
    public class B1RestClient : IDisposable
    {
        private bool disposedValue;


        public static string? CompanyDB { get; set; }
        public static string? UserName { get; set; }
        public static string? Password { get; set; }
        public static string? B1Url { get; set; }

        public static string? SessionId { get; set; }
        public static string? RouteId { get; set; }
        public static bool BypassSSLErrors { get; set; }

        static B1RestClient()
        {
            BypassSSLErrors = true; // allow self-signed SSL certificate
            //LoadSettings();
            if (BypassSSLErrors) System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }

        public void Config(string Company, string user, string pw, string url)
        {
            CompanyDB = Company;// "SandboxUS";
            UserName = user;// "manager";
            Password = pw;// "1234";
            B1Url = url; // "https://DESKTOP-SRC9C6B:50000/b1s/v1/";
        }



        public void Post(string uri, string PostObject, out string status, out string content)
        {
            if (SessionId == null) Login();

            string url = B1Url + uri;

            string postBody = PostObject;

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", $"B1SESSION={SessionId}; ROUTEID={RouteId}");
            request.AddParameter("text/plain", postBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            status = response.StatusCode.ToString();  // "NoContent" or "BadRequest"
            Console.WriteLine(status);
            content = response.Content;

        }

        public string Patch(string uri, string PostObject, out string status)
        {
            if (SessionId == null) Login();

            string url = B1Url + uri;

            string postBody = PostObject;

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", $"B1SESSION={SessionId}; ROUTEID={RouteId}");
            request.AddParameter("text/plain", postBody, ParameterType.RequestBody);
            Console.WriteLine($"PATCH {url}");
            Console.WriteLine(postBody);
            IRestResponse response = client.Execute(request);
            status = response.StatusCode.ToString();  // "NoContent" or "BadRequest"

            return response.Content;
        }

        public string Get(string uri, out string status)
        {
            if (SessionId == null) throw new Exception("No Session ID Found"); //Login();
            status = "";
            try
            {
                string url = B1Url + uri;
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Cookie", $"B1SESSION={SessionId}; ROUTEID={RouteId}");

                Console.WriteLine($"B1RestClient.Get URI {uri}");
                IRestResponse response = client.Execute(request);
                status = response.StatusCode.ToString();
                return response.Content;                                // Returns "OK" or "NotFound" if URL is well-formed; "BadRequest" if not
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public class Items
        {
            public string odatametadata { get; set; }
            public List<Value> value { get; set; }
        }

        public class Value
        {
            public string odataetag { get; set; }
            public string ItemCode { get; set; }
            public string ItemName { get; set; }
            public string Mainsupplier { get; set; }
        }




        public static void getItemsSku(string uri, string ItemCode, out string responseString)
        {
            if (SessionId == null) throw new Exception("No Session ID Found"); //Login();
            string status = "";
            try
            {

                string url = B1Url + uri;
                var client = new RestClient(url);

                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Cookie", $"B1SESSION={SessionId}; ROUTEID={RouteId}");


                IRestResponse response = client.Execute(request);
                responseString = "Add";

                var model = System.Text.Json.JsonSerializer.Deserialize<Items>(response.Content);

                //                   SkuConstructor.jsonString = response.Content;

                //url = null;

                if (model.value != null)
                {
                    foreach (var item in model.value)
                    {
                        if (item.ItemCode != null)
                        {
                            responseString = "Update";
                        }
                        else
                        {
                            responseString = $"Add";
                        }
                    }

                }
                else
                {
                    responseString = $"Add";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting products from B1: " + ex.Message);
                responseString = ex.Message;
            }
        }


        public string Login()
        {
            try
            {
                var client = new RestClient(B1Url + "/Login");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = "{" + string.Format("\"CompanyDB\": \"{0}\", \"UserName\": \"{1}\", \"Password\": \"{2}\"", CompanyDB, UserName, Password) + "}";
                //request.AddJsonBody(body);
               request.AddParameter("text/plain", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);

                foreach (var cookie in response.Cookies)
                {
                    // if (cookie.Name == "ROUTEID") RouteId = cookie.Value;
                }
                SessionId = jsonResponse.SessionId;
                RouteId = jsonResponse.RouteId;
                return SessionId;

            }
            catch (Exception ex)
            {
                SessionId = "";
                throw new Exception(ex.Message);
            }

        }

        public void LogOut()
        {
            try
            {
                var client = new RestClient(B1Url + "Logout");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);

                request.AddCookie("B1SESSION", SessionId);
                request.AddCookie("ROUTEID", RouteId);

                IRestResponse response = client.Execute(request);


                Console.WriteLine("log out complete");

            }
            catch (Exception ex)
            {
                //Logging.LogError(ex.Message, "B1RestClient.LogOut");
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }


                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}

