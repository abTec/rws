using Application.Contracts;
using Application.CQRS.Commands;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.CommandHandlers
{
    internal class UpdateTranslationJobHandler : IRequestHandler<CreateTranslationJob, TranslationJobDto>
    {
        private readonly IMapper mapper;
        private readonly ITranslationJobRepository repository;

        public UpdateTranslationJobHandler(IMapper mapper, ITranslationJobRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public Task<TranslationJobDto> Handle(CreateTranslationJob request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
