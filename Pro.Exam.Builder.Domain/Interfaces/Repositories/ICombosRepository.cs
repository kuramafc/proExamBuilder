using Pro.Exam.Builder.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface ICombosRepository
    {
        Task<IEnumerable<SubjectDto>> GetSubjects(int matterId);
        Task<bool> PostSubject(string subject, int matterId);
        Task<bool> DeleteSubject(int subjectId, int matterId);
        Task<IEnumerable<MatterDto>> GetMatters();
        Task<bool> PostMatter(string subject);
        Task<bool> DeleteMatters(int matterId);
    }
}
