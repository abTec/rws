using Application.Contracts;
using Application.CQRS.Commands;
using Application.Models;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.CommandHandlers
{
    public class CreateTranslatorHandler : IRequestHandler<CreateTranslator, bool>
    {
        private readonly IMapper mapper;
        private readonly ITranslatorRepository repository;

        public CreateTranslatorHandler(IMapper mapper, ITranslatorRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<bool> Handle(CreateTranslator request, CancellationToken cancellationToken) => await repository.Create(mapper.Map<Translator>(request.Translator));
    }
}
