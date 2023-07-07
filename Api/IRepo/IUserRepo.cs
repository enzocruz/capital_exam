using Api.Models;
namespace Api.IRepo
{
    public interface IUserRepo
    {
        IEnumerable<Users> GetUsersByUserNames(IEnumerable<string> userNames);
    }
}