using Pro.Exam.Builder.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        Task<bool> Register(UserDto user);
        Task<bool> Login(UserDto user);
    }
}
