using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Datas.Repositories
{
    public class CombosRepository : ICombosRepository
    {
        public IConnection _connection;

        public CombosRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> PostMatter(string matter, int subjectId)
        {
            await _connection.Execute<string>(@"INSERT INTO Matters (Matter) VALUES (@matter)", new { matter });
            var resultId = await _connection.GetFirstOrDefault<int>("SELECT Id FROM Matters WHERE Matter = @matter", new { matter });
            var result = await _connection.Execute<bool>(@"INSERT INTO MatSub (MatterId, SubjectId) VAlUES (@MatterId, @SubjectId)", new { MatterId = resultId, SubjectId = subjectId });

            return result != null;
        }

        public async Task<IEnumerable<MatterDto>> GetMatters(int subjectId)
        {
            var result = await _connection.Execute<MatterDto>(@"SELECT mt.id, mt.Subject FROM Matters AS mt
                                                                    INNER JOIN MatSub AS ms ON Matter.Id = mt.id 
                                                                    INNER JOIN Subjects AS sj ON sj.id = ms.Subject.Id
                                                                        WHERE sj.id = @subjectId", new { subjectId });

            return result.ToList();
        }

        public async Task<bool> DeleteMatters(int matterId, int subjectId)
        {
            var result = await _connection.Execute<bool>(@"DELETE MatSub where MatterId = @matterId AND SubjectId = @subjectId", new { subjectId, matterId });

            return result != null;
        }

        public async Task<bool> PostSubject(string subject)
        {
            var result = await _connection.Execute<string>(@"INSERT INTO Subjects (Subject) VALUES (@subject)", new { subject });

            return result != null;
        }

        public async Task<IEnumerable<SubjectDto>> GetSubjects()
        {
            var result = await _connection.Execute<SubjectDto>("SELECT * FROM Subjects");

            return result.ToList();
        }

        public async Task<bool> DeleteSubject(int subjectId)
        {
            var result = await _connection.Execute<bool>("DELETE Subjects where Id = @subjectId", new { subjectId });

            return result != null;
        }
    }
}
