using Q10.Domain.Entities;

namespace Q10.Application.Students.Commands
{
    public interface IStudentHandler
    {
        Task<Student> CreateStudent(Student entity, CancellationToken cancellationToken);
        Task<IEnumerable<Student>?> GetAll(CancellationToken cancellationToken);
        Task<Student?> GetByID(int id, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(Student entity, CancellationToken cancellationToken);
    }
}