using Api.Models;
using Api.IRepo;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;
using Api.Helper;
namespace Api.Repo
{
    public class UserRepository : IUserRepo
    {

        private readonly GithubHelper _helper;
        public UserRepository()
        {
            _helper = new GithubHelper();
        }
        public IEnumerable<Users> GetUsersByUserNames(IEnumerable<string> userNames)
        {
            List<Users> userList = new List<Users>();
            userNames = userNames.Distinct();

            userList = _helper.GetUsers(userNames).ToList();
            return userList.OrderBy(f => f.name);
        }
    }
}