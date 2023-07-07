using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Repo;
using Api.IRepo;
using Api.Servcies;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {


        [HttpPost]
        [Route("/retrieveUsers")]
        public IActionResult retrieveUsers(IEnumerable<string> usernames)
        {
            var service = new UserService(new UserRepository());
            IEnumerable<Users> users = service.GetUsersByUsernames(usernames);
            return Ok(users);
        }

    }
}


