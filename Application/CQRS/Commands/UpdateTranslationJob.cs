using Application.Models;
using MediatR;

namespace Application.CQRS.Commands
{
    public class UpdateTranslationJob : IRequest<TranslationJobDto>
    {
        public int TranslationJobId { get; set; }
        public int TranslatorID { get; set; }
        public string NewStatus { get; set; }
    }
}
