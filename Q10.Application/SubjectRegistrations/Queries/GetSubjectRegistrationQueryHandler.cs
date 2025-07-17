using MediatR;
using Q10.Domain.Dtos;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.SubjectRegistrations.Queries
{
    public class GetSubjectRegistrationByStudentIdQuery : IRequest<SubjectRegistrationDto?>
    {
        public int StudentId { get; set; }
    }

    public class GetSubjectRegistrationQueryHandler(ISubjectRegistrationRepository _subjectRegistrationRepository) :
        IRequestHandler<GetSubjectRegistrationByStudentIdQuery, SubjectRegistrationDto?>
    {
        public async Task<SubjectRegistrationDto?> Handle(GetSubjectRegistrationByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _subjectRegistrationRepository.GetByID(request.StudentId, cancellationToken);
            return new SubjectRegistrationDto
            {
                Id = result!.Id,
                StudentId = result.StudentId,
                SubjectId = result.SubjectId,
                Success = true
            };
        }
    }
}
