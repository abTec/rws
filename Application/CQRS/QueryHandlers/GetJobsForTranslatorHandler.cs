using Application.Contracts;
using Application.CQRS.Queries;
using Application.Models;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.QueryHandlers
{
    public class GetJobsForTranslatorHandler : IRequestHandler<GetJobsForTranslator, ICollection<TranslationJobDto>>
    {
        private readonly ITranslationJobRepository _repository;
        private readonly IMapper _mapper;

        public GetJobsForTranslatorHandler(ITranslationJobRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<TranslationJobDto>> Handle(GetJobsForTranslator request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TranslationJobDto[]>(await _repository.GetAllJobsForTranslator(request.TranslatorId));
        }
    }
}
