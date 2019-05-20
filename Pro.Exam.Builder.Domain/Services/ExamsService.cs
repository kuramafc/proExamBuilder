using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Documents;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Services
{
    public class ExamsService : IExamsService
    {
        private readonly IExamsRepository _examsRepository;
        private readonly IDocumentDocX _documentDocX;

        public ExamsService(IExamsRepository examsRepository, IDocumentDocX documentDocX)
        {
            _examsRepository = examsRepository;
            _documentDocX = documentDocX;
        }

        public Task<string> ExamGerenate(QuestionsDto question)
        {
            _documentDocX.CreateDocument(question);

            return _examsRepository.ExamGerenate(question);
        }

        public Task<bool> DeleteQuestion(long questionCode)
        {
            return _examsRepository.DeleteQuestion(questionCode);
        }

        public Task<bool> RegisterQuestion(Question question)
        {
            return _examsRepository.RegisterQuestion(question);
        }

        public async Task<QuestionsDto> ExamGerenatePreview(ExamDto exam)
        {
           var size = exam.QuestionParams.Count;
            QuestionsDto questionsResult = new QuestionsDto() { ExamType = exam.ExamType };

            if (size > 0)
            {
                foreach(var question in exam.QuestionParams)
                {
                   var result = await _examsRepository.QuestionPreview(question, exam.ExamType);

                    if (result != null)
                    {
                        questionsResult.Questions.Add(result);
                    }
                }
            }

            return questionsResult;
        }

        public async Task<IEnumerable<Question>> GetQuestions(string userEmail)
        {
            return await _examsRepository.GetQuestions(userEmail);
        }
    }
}
