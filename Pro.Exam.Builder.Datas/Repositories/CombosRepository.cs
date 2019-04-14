using Pro.Exam.Builder.Domain.Interfaces;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Datas.Repositories
{
    public class CombosRepository : ICombosRepository
    {
        public IConnection _connection;

        public CombosRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<string>> GetMatters()
        {
            var result = await _connection.Execute<string>("Select Matter from Matters");

            return result;
        }

        public async Task PostSubject(string subject)
        {
            await _connection.Execute<string>(@"insert into Subjects (Subject) values (@subject)", new { subject });
        }

        public async Task<IEnumerable<string>> GetSubjects()
        {
            var result = await _connection.Execute<string>("Select Subject from Subjects");

            return result;
        }
    }
}
