using Q10.Domain.Entities;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.Students.Commands
{
    public class StudentHandler(IRepositoryBase<Student> _studentRepository) : IStudentHandler
    {
        public async Task<Student> CreateStudent(Student entity, CancellationToken cancellationToken)
        {
            Student entityStudent = await _studentRepository.Create(entity, cancellationToken);
            return entityStudent;
        }

        public async Task<IEnumerable<Student>?> GetAll(CancellationToken cancellationToken)
        {
            IEnumerable<Student> CurrentStudent = await _studentRepository.GetAll(cancellationToken);
            if (CurrentStudent != null)
            {
                return CurrentStudent;
            }
            return null;
        }

        public async Task<Student?> GetByID(int id, CancellationToken cancellationToken)
        {
            Student? CurrentCustomer = await _studentRepository.GetByID(id, cancellationToken);
            if (CurrentCustomer != null)
            {
                return CurrentCustomer;
            }
            return null;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _studentRepository.Delete(id, cancellationToken);
        }

        public async Task Update(Student entity, CancellationToken cancellationToken)
        {
            await _studentRepository.Update(entity, cancellationToken);
        }

        public async Task<IEnumerable<Student>?> GetDropDownList(CancellationToken cancellationToken)
        {
            IEnumerable<Student> CurrentStudent = await _studentRepository.GetAll(cancellationToken);
            if (CurrentStudent != null)
            {
                return CurrentStudent;
            }
            return null;
        }
    }
}
