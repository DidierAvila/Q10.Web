using MediatR;
using Q10.Domain.Entities;
using Q10.Infrastructure.Repositories;

namespace Q10.Application.Subjects.Queries
{
    public class GetSubjectsQuery : IRequest<IEnumerable<Subject>?>
    {
    }

    public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, IEnumerable<Subject>?>
    {
        private readonly IRepositoryBase<Subject> _subjectRepository;

        public GetSubjectsQueryHandler(IRepositoryBase<Subject> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<IEnumerable<Subject>?> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Subject> currentSubjects = await _subjectRepository.GetAll(cancellationToken);
            return currentSubjects;
        }
    }
}
