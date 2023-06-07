using MediatR;

namespace Application.CQRS.Commands
{
    public class AssignJob : IRequest<bool>
    {
        public int JobId { get; set; }
        public int TranslatorId { get; set; }
    }
}
