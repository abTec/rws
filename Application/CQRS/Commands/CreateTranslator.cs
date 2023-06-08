using Application.Models;
using MediatR;

namespace Application.CQRS.Commands
{
    public sealed class CreateTranslator : IRequest<bool>
    {
        public TranslatorDto Translator { get; set; }
    }
}
