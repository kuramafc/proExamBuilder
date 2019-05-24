﻿using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Enums;
using Pro.Exam.Builder.Domain.Interfaces;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Models;
using System;
using System.Collections.Generic;
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

        public Task<string> ExamGerenate(QuestionsDto question)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetQuestions(string userEmail)
        {
            return await _connection.Execute<Question>(@"SELECT * FROM Questions WHERE Author");
        }

        public async Task<Question> QuestionPreview(QuestionParams param, ExamTypeEnum type)
        {
            if (type == ExamTypeEnum.N2)
            {
                return  await _connection.GetFirstOrDefault<Question>(@"SELECT top 1 * FROM Questions WHERE MatterId = @MatterId and SubjectId = @SubjectId and HasOption = HasOption and Difficult = @Difficult and Used = 0", param);
            } 

            return await _connection.GetFirstOrDefault<Question>(@"SELECT top 1 * FROM Questions WHERE MatterId = @MatterId and SubjectId = @SubjectId and HasOption = HasOption and Difficult = @Difficult", param);
        }

        public async Task<bool> RegisterQuestion(Question question)
        {
            var code = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;
            question.Code = code;

            var result = await _connection.Execute<Question>(@"INSERT INTO Questions (QuestionName, Difficult, RightQuestion, Used, Image, Author, HasOption, MatterId, SubjectId, Code)
                                                                VALUES (@QuestionName, @Difficult, @RightQuestion, @Used, @Image, @Author, @HasOption, @MatterId, @SubjectId, @Code)", question);

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
