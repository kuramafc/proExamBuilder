using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces;
using Pro.Exam.Builder.Domain.Interfaces.Services;
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
        public async Task<bool> Login(UserDto user)
        {
            var result = await _connection.GetFirstOrDefault<UserDto>("SELECT * FROM users WHERE Email = @Email AND Password =  @Password AND Type = @Type", user);

            return result != null;
        }

        public async Task<bool> Register(UserDto user)
        {
           var result = await _connection.Execute<UserDto>("INSERT INTO Users (UserName, Password, Email, Type, Code) values (@UserName, @Password, @Email, @Type, @Code)", user);

            return result != null;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var result = await _connection.Execute<UserDto>("SELECT * FROM Users");

            return result.ToList();
        }
    }
}
