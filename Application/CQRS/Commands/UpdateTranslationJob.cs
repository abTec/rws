using Application.Contracts;
using MediatR;

namespace Application.CQRS.Commands
{
    public class UpdateTranslationJob : IRequest<bool>
    {
        public int TranslationJobId { get; set; }
        public int TranslatorId { get; set; }
        public JobStatus NewStatus { get; set; }
    }
}
