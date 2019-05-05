﻿using Pro.Exam.Builder.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Interfaces.Services
{
    public interface ICombosService
    {
        Task<IEnumerable<SubjectDto>> GetSubjects();
        Task<bool> PostSubject(string subject);
        Task<bool> DeleteSubject(int subjectId);
        Task<IEnumerable<MatterDto>> GetMatters(int subjectId);
        Task<bool> PostMatter(string subject, int subjectId);
        Task<bool> DeleteMatter(int matterId, int subjectId);
    }
}
