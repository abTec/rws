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
    internal class UpdateTranslationJobHandler : IRequestHandler<CreateTranslationJob, bool>
    {
        private readonly IMapper mapper;
        private readonly ITranslationJobRepository repository;

        public UpdateTranslationJobHandler(IMapper mapper, ITranslationJobRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public Task<bool> Handle(CreateTranslationJob request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
