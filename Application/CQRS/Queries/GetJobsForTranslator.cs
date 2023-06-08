using Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.CQRS.Queries
{
    public sealed class GetJobsForTranslator : IRequest<ICollection<TranslationJobDto>>
    {
        public int TranslatorId { get; set; }
    }
}
