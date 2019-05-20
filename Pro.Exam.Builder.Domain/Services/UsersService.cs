using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<UserResponse> Login(UserDto user)
        {
            return _usersRepository.Login(user);
        }

        public Task<bool> Register(UserDto user)
        {
            return _usersRepository.Register(user);
        }

        public Task<IEnumerable<UserResponse>> GetUsers()
        {
            return _usersRepository.GetUsers();
        }

        public Task<bool> DeleteUser(string code)
        {
            return _usersRepository.DeleteUser(code);
        }
    }
}
