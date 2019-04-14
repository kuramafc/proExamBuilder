using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces
{
    public interface IConnection
    {
        Task<IEnumerable<T>> Execute<T>(string query, object param = null);
    }
}
