using Pro.Exam.Builder.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface IUsersRepository
    {
        Task<bool> Register(UserDto user);
        Task<bool> Login(UserDto user);
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
