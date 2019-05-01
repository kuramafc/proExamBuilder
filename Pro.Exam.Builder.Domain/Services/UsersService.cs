using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<bool> Login(UserDto user)
        {
            return _usersRepository.Login(user);
        }

        public Task<bool> Register(UserDto user)
        {
            return _usersRepository.Register(user);
        }
    }
}
