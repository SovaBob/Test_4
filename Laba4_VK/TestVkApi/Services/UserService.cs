using Tests.Models;
using Tests.Repositories;

namespace Tests.Services
{
    public class UserService
    {
        private IUsersRepository _usersRepository;

        public UserService(IUsersRepository userRepository)
        {
            _usersRepository = userRepository;
        }

        public User GetUserById(string id)
        {
            return _usersRepository.GetUserById(id);
        }
    }
}