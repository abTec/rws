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
    public class CreateTranslationJobHandler : IRequestHandler<CreateTranslationJob, bool>
    {
        private readonly IMapper _mapper;
        private readonly ITranslationJobRepository _repository;
        private readonly IPriceCalculator _priceCalculator;

        public CreateTranslationJobHandler(IMapper mapper, ITranslationJobRepository repository, IPriceCalculator priceCalculator)
        {
            _mapper = mapper;
            _repository = repository;
            _priceCalculator = priceCalculator;
        }

        public async Task<bool> Handle(CreateTranslationJob request, CancellationToken cancellationToken)
        {
            var job = new TranslationJob
            {
                CustomerName = request.Model.CustomerName,
                OriginalContent = request.Model.OriginalContent,
                TranslatedContent = request.Model.TranslatedContent,
                Status = JobStatus.New.ToString(),
                Price = _priceCalculator.CalculatePrice(request.Model.OriginalContent.Length),
            };

            return await _repository.Create(job);
        }
    }
}
