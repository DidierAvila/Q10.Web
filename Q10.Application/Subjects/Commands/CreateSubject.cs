using MediatR;
using Q10.Domain.Entities;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.Subjects.Commands
{
    public record class CreateSubjectCommand : IRequest<Subject?>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
    }

    public class CreateSubject : IRequestHandler<CreateSubjectCommand, Subject?>
    {
        private readonly IRepositoryBase<Subject> _SubjectRepository;

        public CreateSubject(IRepositoryBase<Subject> subjectRepository)
        {
            _SubjectRepository = subjectRepository;
        }

        public async Task<Subject?> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject entity = new()
            {
                Name = request.Name,
                Code = request.Code,
                Credit = request.Credit
            };

            Subject entityStudent = await _SubjectRepository.Create(entity, cancellationToken);
            return entityStudent;
        }
    }
}
