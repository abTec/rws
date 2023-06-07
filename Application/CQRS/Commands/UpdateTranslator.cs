using Application.Contracts;
using MediatR;

namespace Application.CQRS.Commands
{
    public class UpdateTranslator : IRequest<bool>
    {
        public int TranslatorId { get; set; }
        public TranslatorStatus NewStatus { get; set; }
    }
}
