using MediatR;

namespace Application.CQRS.Commands
{
    public sealed class AssignJob : IRequest<bool>
    {
        public int JobId { get; set; }
        public int TranslatorId { get; set; }
    }
}
