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

        public Task<IEnumerable<MatterDto>> GetMatters()
        {
            return _combosRepository.GetMatters();
        }

        public Task<bool> PostMatter(string matter)
        {
            return _combosRepository.PostMatter(matter);
        }

        public Task<bool> DeleteMatter(int matterId)
        {
            return _combosRepository.DeleteMatters(matterId);
        }

        public Task<bool> PostSubject(string subject, int matterId)
        {
            return _combosRepository.PostSubject(subject, matterId);
        }

        public Task<IEnumerable<SubjectDto>> GetSubjects(int matterId)
        {
            return _combosRepository.GetSubjects(matterId);
        }

        public Task<bool> DeleteSubject(int subjectId, int matterId)
        {
            return _combosRepository.DeleteSubject(subjectId, matterId);
        }
    }
}
