using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Models;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface IExamsRepository
    {
        Task<bool> RegisterQuestion(Question question);
        Task<bool> DeleteQuestion(long questionCode);
        Task<string> ExamGerenate(ExamDto exam);
    }
}
