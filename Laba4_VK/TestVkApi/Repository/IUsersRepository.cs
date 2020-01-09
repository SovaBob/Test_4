using Tests.Models;

namespace Tests.Repositories
{
    public interface IUsersRepository
    {
        User GetUserById(string id);
    }
}