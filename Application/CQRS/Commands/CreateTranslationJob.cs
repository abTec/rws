using Application.Models;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateTranslationJob : IRequest<TranslationJobDto>
    {
    }
}
