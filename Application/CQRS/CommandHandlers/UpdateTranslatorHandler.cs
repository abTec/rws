using Application.Contracts;
using Application.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.CommandHandlers
{
    public sealed class UpdateTranslatorHandler : IRequestHandler<UpdateTranslator, bool>
    {
        private readonly ITranslatorRepository _repository;

        public UpdateTranslatorHandler(ITranslatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTranslator request, CancellationToken cancellationToken) => await _repository.UpdateStatus(request.TranslatorId, request.NewStatus.ToString());
    }
}
