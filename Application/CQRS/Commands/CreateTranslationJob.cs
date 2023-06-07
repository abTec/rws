using Application.Models;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateTranslationJob : IRequest<bool>
    {
        public TranslationJobDto Model { get; set; }
    }
}
