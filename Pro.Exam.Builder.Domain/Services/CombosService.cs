using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Domain.Services
{
    public class CombosService : ICombosService
    {
        private readonly ICombosRepository _combosRepository;

        public CombosService(ICombosRepository combosRepository)
        {
            _combosRepository = combosRepository;
        }

        public Task<IEnumerable<MatterDto>> GetMatters(int subjectId)
        {
            return _combosRepository.GetMatters(subjectId);
        }

        public Task<bool> PostMatter(string matter, int subjectId)
        {
            return _combosRepository.PostMatter(matter, subjectId);
        }

        public Task<bool> DeleteMatter(int matterId, int subjectId)
        {
            return _combosRepository.DeleteMatters(matterId, subjectId);
        }

        public Task<bool> PostSubject(string subject)
        {
            return _combosRepository.PostSubject(subject);
        }

        public Task<IEnumerable<SubjectDto>> GetSubjects()
        {
            return _combosRepository.GetSubjects();
        }

        public Task<bool> DeleteSubject(int subjectId)
        {
            return _combosRepository.DeleteSubject(subjectId);
        }
    }
}
