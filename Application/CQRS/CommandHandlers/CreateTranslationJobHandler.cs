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
    public class CreateTranslationJobHandler : IRequestHandler<CreateTranslationJob, TranslationJobDto>
    {
        private readonly IMapper _mapper;
        private readonly ITranslationJobRepository _repository;

        public CreateTranslationJobHandler(IMapper mapper, ITranslationJobRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TranslationJobDto> Handle(CreateTranslationJob request, CancellationToken cancellationToken)
        {
            var job = new TranslationJob
            {

            };

            return _mapper.Map<TranslationJobDto>(await _repository.Create(job));
        }
    }
}
