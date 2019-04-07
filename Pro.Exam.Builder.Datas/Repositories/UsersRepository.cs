using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Datas.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public Task Login(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task Register(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
