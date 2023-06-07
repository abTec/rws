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
    public class GetAllTranslationJobsHandler : IRequestHandler<GetAllTranslationJobs, ICollection<TranslationJobDto>>
    {
        private readonly IMapper mapper;
        private readonly ITranslationJobRepository repository;

        public GetAllTranslationJobsHandler(IMapper mapper, ITranslationJobRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ICollection<TranslationJobDto>> Handle(GetAllTranslationJobs request, CancellationToken cancellationToken) => mapper.Map<TranslationJobDto[]>(await repository.GetAllAsync());
    }
}
