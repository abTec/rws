using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.CQRS.Queries
{
    public class GetTranslatorsByName : IRequest<ICollection<TranslatorDto>>
    {
        public string Name { get; set; }
    }
}
