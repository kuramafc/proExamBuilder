using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface IUsersRepository
    {
        Task<bool> Register(UserDto user);
        Task<UserResponse> Login(UserDto user);
        Task<IEnumerable<UserResponse>> GetUsers();
        Task<bool> DeleteUser(string code);
    }
}
