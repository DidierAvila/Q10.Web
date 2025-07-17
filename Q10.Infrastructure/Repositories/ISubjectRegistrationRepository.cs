using Q10.Domain.Dtos;
using Q10.Domain.Entities;

namespace Q10.Infrastructure.Repositories
{
    public interface ISubjectRegistrationRepository : IRepositoryBase<SubjectRegistration>
    {
        Task<IEnumerable<SubjectRegistrationDto>> GetRegistrationsByStudentId(int studentId, CancellationToken cancellationToken);
    }
}