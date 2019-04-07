using Pro.Exam.Builder.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Datas.Repositories
{
    public class CombosRepository : ICombosRepository
    {
        public Task<IEnumerable<string>> GetMatters()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetSubjects()
        {
            throw new NotImplementedException();
        }
    }
}
