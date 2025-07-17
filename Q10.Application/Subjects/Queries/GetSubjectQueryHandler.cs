using MediatR;
using Q10.Domain.Entities;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.Subjects.Queries
{
    public class GetSubjectQuery : IRequest<Subject?>
    {
        public int Id { get; set; }
    }

    public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, Subject?>
    {
        private readonly IRepositoryBase<Subject> _subjectRepository;

        public GetSubjectQueryHandler(IRepositoryBase<Subject> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject?> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
        {
            return await _subjectRepository.GetByID(request.Id, cancellationToken);
        }
    }
}
