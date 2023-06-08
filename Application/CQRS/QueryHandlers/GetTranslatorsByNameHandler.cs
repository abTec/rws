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
    public sealed class GetTranslatorsByNameHandler : IRequestHandler<GetTranslatorsByName, ICollection<TranslatorDto>>
    {
        private readonly IMapper mapper;
        private readonly ITranslatorRepository repository;

        public GetTranslatorsByNameHandler(IMapper mapper, ITranslatorRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ICollection<TranslatorDto>> Handle(GetTranslatorsByName request, CancellationToken cancellationToken)
        {
            return mapper.Map<TranslatorDto[]>(await repository.GetByName(request.Name));
        }
    }
}
