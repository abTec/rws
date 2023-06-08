using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.CQRS.Queries
{
    public sealed class GetAllTranslators : IRequest<ICollection<TranslatorDto>>
    {
    }
}
