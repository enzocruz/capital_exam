using Api.IRepo;
using Api.Repo;
using Api.Models;
namespace Api.Servcies
{
    public class UserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            this._userRepo = userRepo;
        }
        public IEnumerable<Users> GetUsersByUsernames(IEnumerable<string> usernames)
        {
            return this._userRepo.GetUsersByUserNames(usernames).ToList();
        }

    }
}