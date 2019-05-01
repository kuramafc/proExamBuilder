using Pro.Exam.Builder.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface ICombosService
    {
        Task<IEnumerable<SubjectDto>> GetSubjects(int matterId);
        Task<bool> PostSubject(string subject, int matterId);
        Task<bool> DeleteSubject(int subjectId, int matterId);
        Task<IEnumerable<MatterDto>> GetMatters();
        Task<bool> PostMatter(string subject);
        Task<bool> DeleteMatter(int matterId);
    }
}
