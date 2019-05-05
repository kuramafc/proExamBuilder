using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Models;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Services
{
    public class ExamsService : IExamsService
    {
        private readonly IExamsRepository _examsRepository;

        public ExamsService(IExamsRepository examsRepository)
        {
            _examsRepository = examsRepository;
        }

        public Task<string> ExamGerenate(ExamDto exam)
        {
            return _examsRepository.ExamGerenate(exam);
        }

        public Task<bool> DeleteQuestion(long questionCode)
        {
            return _examsRepository.DeleteQuestion(questionCode);
        }

        public Task<bool> RegisterQuestion(Question question)
        {
            return _examsRepository.RegisterQuestion(question);
        }
    }
}
