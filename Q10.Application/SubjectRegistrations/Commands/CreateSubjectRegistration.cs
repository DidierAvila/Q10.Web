using MediatR;
using Q10.Domain.Dtos;
using Q10.Domain.Entities;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.SubjectRegistrations.Commands
{
    public record class CreateSubjectRegistrationCommand : IRequest<SubjectRegistrationDto?>
    {
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
    }

    public class CreateSubjectRegistration(ISubjectRegistrationRepository _subjectRegistrationRepository, IRepositoryBase<Subject> _SubjectRepository) : 
        IRequestHandler<CreateSubjectRegistrationCommand, SubjectRegistrationDto?>
    {
        public async Task<SubjectRegistrationDto?> Handle(CreateSubjectRegistrationCommand request, CancellationToken cancellationToken)
        {
            // Validate the SubjectId and StudentId
            var result = await _subjectRegistrationRepository.GetRegistrationsByStudentId(request.StudentId, cancellationToken);
            if (result != null || result!.Any())
            {
                // Check if the student has already registered for the subject
                var existingRegistration = result!.FirstOrDefault(x => x.SubjectId == request.SubjectId);
                if (existingRegistration != null)
                {
                    // If the student has already registered for the subject, return an error message
                    return new SubjectRegistrationDto()
                    {
                        Success = false,
                        ErrorMessage = "El estudiante ya está registrado en esta materia."
                    };
                }

                var subjectCredits = await _SubjectRepository.GetByID(request.SubjectId, cancellationToken);
                if (subjectCredits != null && subjectCredits.Credit == 4)
                {
                    var subject = result!.Where(x => x.Credit >= 4).Count();
                    if (subject >= 3)
                    {
                        // If the student has already registered for 3 subjects with 4 credits, return an error message
                        return new SubjectRegistrationDto()
                        {
                            Success = false,
                            ErrorMessage = "El estudiante no puede registrar más de 3 materias de 4 créditos."
                        };
                    }
                }
            }
            var entityStudent = await _subjectRegistrationRepository.Create(new SubjectRegistration() { StudentId = request.StudentId, SubjectId = request.SubjectId}, cancellationToken);
            return new SubjectRegistrationDto()
            {
                Id = entityStudent.Id,
                StudentId = entityStudent.StudentId,
                SubjectId = entityStudent.SubjectId,
                Success = true,
            };
        }
    }
}
