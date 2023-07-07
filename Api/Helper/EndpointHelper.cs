using Api.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Api.Helper
{
    public class GithubHelper
    {
        private RestClient? _client;
        private readonly RestRequest _request;
        public GithubHelper()
        {
            _request = new RestRequest();
        }
        public IEnumerable<Users> GetUsers(IEnumerable<string> users)
        {
            List<Users> userList = new List<Users>();
            foreach (var username in users)
            {
                //Console.WriteLine(username);
                var url = string.Format("https://api.github.com/users/{0}", username);
                RestResponse response;

                var options = new RestClientOptions(url)
                {

                };
                try
                {
                    _client = new RestClient(options);
                    _client!.AddDefaultHeader("Accept", "application/vnd.github+json");


                    response = _client.ExecuteGet(_request);
                    //Console.WriteLine(response.StatusCode);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var user = JsonConvert.DeserializeObject<Users>(response.Content);
                        // Console.WriteLine("founded " + username);
                        userList.Add(user);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            return userList;
        }
    }
}