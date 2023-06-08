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
    public sealed class GetAllTranslatorsHandler : IRequestHandler<GetAllTranslators, ICollection<TranslatorDto>>
    {
        private readonly IMapper mapper;
        private readonly ITranslatorRepository repository;

        public GetAllTranslatorsHandler(IMapper mapper, ITranslatorRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ICollection<TranslatorDto>> Handle(GetAllTranslators request, CancellationToken cancellationToken) => mapper.Map<TranslatorDto[]>(await repository.GetAllAsync());
    }
}
