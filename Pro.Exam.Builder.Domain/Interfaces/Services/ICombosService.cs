using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface ICombosService
    {
        Task<IEnumerable<string>> GetSubjects();
        Task PostSubject(string subject);
        Task<IEnumerable<string>> GetMatters();
    }
}
