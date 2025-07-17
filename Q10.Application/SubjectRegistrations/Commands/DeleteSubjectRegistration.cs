using MediatR;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.SubjectRegistrations.Commands
{
    public record DeleteSubjectRegistrationCommand() : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSubjectRegistration(ISubjectRegistrationRepository _subjectRegistrationRepository) : IRequestHandler<DeleteSubjectRegistrationCommand>
    {
        public async Task Handle(DeleteSubjectRegistrationCommand request, CancellationToken cancellationToken)
        {
            await _subjectRegistrationRepository.Delete(request.Id, cancellationToken);
        }
    }
}
