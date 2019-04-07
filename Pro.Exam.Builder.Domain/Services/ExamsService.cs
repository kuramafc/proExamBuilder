using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task RegisterQuestions(QuestionsDto questions)
        {
            return _examsRepository.RegisterQuestions(questions);
        }
    }
}
