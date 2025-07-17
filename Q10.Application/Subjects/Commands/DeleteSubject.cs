using MediatR;
using Q10.Domain.Entities;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.Subjects.Commands
{
    public record DeleteSubjectCommand() : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteSubject(IRepositoryBase<Subject> _SubjectRepository) : IRequestHandler<DeleteSubjectCommand>
    {
        public async Task Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
           await _SubjectRepository.Delete(request.Id, cancellationToken);
        }
    }
}
