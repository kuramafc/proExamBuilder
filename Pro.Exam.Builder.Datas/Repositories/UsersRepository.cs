using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Datas.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public IConnection _connection;

        public UsersRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<UserResponse> Login(UserDto user)
        {
            var result = await _connection.GetFirstOrDefault<UserResponse>("SELECT * FROM users WHERE Email = @Email AND Password =  @Password", user);

            return result;
        }

        public async Task<bool> Register(UserDto user)
        {
           var result = await _connection.Execute<UserDto>("INSERT INTO Users (UserName, Password, Email, Type, Code) values (@UserName, @Password, @Email, @Type, @Code)", user);

            return result != null;
        }

        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            var result = await _connection.Execute<UserResponse>("SELECT * FROM Users");

            return result.ToList();
        }

        public async Task<bool> DeleteUser(string code)
        {
            var result = await _connection.Execute<bool>("DELETE Users WHERE Code = @Code)", code);

            return result != null;
        }
    }
}
