using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Datas.Repositories
{
    public class ExamsRepository : IExamsRepository
    {
        public Task<string> ExamGerenate(ExamDto exam)
        {
            throw new NotImplementedException();
        }

        public Task RegisterQuestions(QuestionsDto questions)
        {
            throw new NotImplementedException();
        }
    }
}
