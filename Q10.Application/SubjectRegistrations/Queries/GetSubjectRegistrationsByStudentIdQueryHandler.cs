using MediatR;
using Q10.Domain.Dtos;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.SubjectRegistrations.Queries
{
    public class GetSubjectRegistrationsByStudentIdQuery : IRequest<IEnumerable<SubjectRegistrationDto>?>
    {
        public int StudentId { get; set; }
    }

    public class GetSubjectRegistrationsByStudentIdQueryHandler(ISubjectRegistrationRepository _subjectRegistrationRepository) : 
        IRequestHandler<GetSubjectRegistrationsByStudentIdQuery, IEnumerable<SubjectRegistrationDto>?>
    {
        public async Task<IEnumerable<SubjectRegistrationDto>?> Handle(GetSubjectRegistrationsByStudentIdQuery request, CancellationToken cancellationToken)
        {
            // Validate the StudentId
            IEnumerable<SubjectRegistrationDto>? currentSubjectRegistration = await _subjectRegistrationRepository.GetRegistrationsByStudentId(request.StudentId, cancellationToken);
            if (currentSubjectRegistration != null || currentSubjectRegistration!.Any())
            {
                return currentSubjectRegistration;
            }
            return null;
        }
    }
}
