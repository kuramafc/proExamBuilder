using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Datas.Repositories
{
    public class ExamsRepository : IExamsRepository
    {
        public IConnection _connection;

        public ExamsRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> DeleteQuestion(long questionCode)
        {
            var result = await _connection.Execute<bool>("DELETE Questions where Code = @questionCode", new { questionCode });

            if (result != null)
            {
                result = await _connection.Execute<bool>("DELETE QuestionsOptions where QuestionCode = @questionCode", new { questionCode });
            }

            return result != null;
        }

        public Task<string> ExamGerenate(ExamDto exam)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterQuestion(Question question)
        {
            var code = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;
            question.Code = code;

            var result = await _connection.Execute<Question>(@"INSERT INTO Questions (Difficult, RightQuestion, Used, Image, Author, HasOption, MatterId, SubjectId, Code)
                                                                VALUES (@Difficult, @RightQuestion, @Used, @Image, @Author, @HasOption, @MatterId, @SubjectId, @Code)", question);

            if (result != null)
            {
                foreach(string x in question.Options)
                {
                    result = await _connection.Execute<Question>(@"INSERT INTO QuestionsOptions (Description, QuestionCode) VALUES (@Description, @QuestionCode)", new { QuestionCode = code, Description = x });
                }
            }

            return result != null;
        }
    }
}
