using MediatR;
using Q10.Domain.Entities;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.Subjects.Commands
{

    public record class UpdateSubjectCommand : IRequest<Subject?>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
    }

    public class UpdateSubject : IRequestHandler<UpdateSubjectCommand, Subject?>
    {
        private readonly IRepositoryBase<Subject> _SubjectRepository;

        public UpdateSubject(IRepositoryBase<Subject> subjectRepository)
        {
            _SubjectRepository = subjectRepository;
        }
        public async Task<Subject?> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            Subject entity = new()
            {
                Id = request.Id,
                Name = request.Name,
                Code = request.Code,
                Credit = request.Credit
            };

            await _SubjectRepository.Update(entity, cancellationToken);
            return entity;
        }
    }
}
