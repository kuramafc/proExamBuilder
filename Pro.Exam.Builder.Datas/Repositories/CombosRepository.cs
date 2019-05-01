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

        public async Task<bool> PostMatter(string matter)
        {
            var result = await _connection.Execute<string>(@"INSERT INTO Matters (Matter) VALUES (@matter)", new { matter });

            return result != null;
        }

        public async Task<IEnumerable<MatterDto>> GetMatters()
        {
            var result = await _connection.Execute<MatterDto>("SELECT * FROM Matters");

            return result.ToList();
        }

        public async Task<bool> DeleteMatters(int matterId)
        {
            var result = await _connection.Execute<bool>("DELETE Matters where Id = @matterId", new { matterId });

            return result != null;
        }

        public async Task<bool> PostSubject(string subject, int matterId)
        {
            await _connection.Execute<string>(@"INSERT INTO Subjects (Subject) VALUES (@subject)", new { subject });
            var resultId = await _connection.GetFirstOrDefault<int>("SELECT Id FROM Subjects WHERE Subject = @subject", new { subject });
            var result = await _connection.Execute<bool>(@"INSERT INTO MatSub (MatterId, SubjectId) VAlUES (@MatterId, @SubjectId)", new { MatterId = matterId, SubjectId = resultId });

            return result != null;
        }

        public async Task<IEnumerable<SubjectDto>> GetSubjects(int matterId)
        {
            var result = await _connection.Execute<SubjectDto>(@"SELECT sj.id, sj.Subject FROM Subjects AS sj
                                                                    INNER JOIN MatSub AS ms ON SubjectId = sj.id 
                                                                    INNER JOIN Matters AS mt ON mt.id = ms.MatterId
                                                                        WHERE mt.id = @matterId", new { matterId });

            return result.ToList();
        }

        public async Task<bool> DeleteSubject(int subjectId, int matterId)
        {
            var result = await _connection.Execute<bool>(@"DELETE MatSub where MatterId = @matterId AND SubjectId = @subjectId", new { subjectId, matterId });

            return result != null;
        }
    }
}
