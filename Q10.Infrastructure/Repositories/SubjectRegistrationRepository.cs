using Microsoft.EntityFrameworkCore;
using Q10.Domain.Dtos;
using Q10.Domain.Entities;
using Q10.Infrastructure.DbContexts;

namespace Q10.Infrastructure.Repositories
{
    public class SubjectRegistrationRepository : RepositoryBase<SubjectRegistration>, ISubjectRegistrationRepository
    {
        public SubjectRegistrationRepository(Q10DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SubjectRegistrationDto>> GetRegistrationsByStudentId(int studentId, CancellationToken cancellationToken)
        {
            var query = from sr in _context.SubjectRegistrations
                        join student in _context.Students on sr.StudentId equals student.Id
                        join subject in _context.Subjects on sr.SubjectId equals subject.Id
                        where sr.StudentId == studentId
                        select new SubjectRegistrationDto
                        {
                            Id = sr.Id,
                            SubjectId = sr.SubjectId,
                            StudentId = sr.StudentId,
                            StudentName = student.Name,
                            SubjectName = subject.Name,
                            Credit = subject.Credit,
                        };

            return await query.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
