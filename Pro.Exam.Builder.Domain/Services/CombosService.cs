using Pro.Exam.Builder.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<IEnumerable<string>> GetMatters()
        {
            return _combosRepository.GetMatters();
        }

        public Task<IEnumerable<string>> GetSubjects()
        {
            return _combosRepository.GetSubjects();
        }
    }
}
