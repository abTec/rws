using Application.Contracts;
using Application.CQRS.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.CommandHandlers
{
    internal class UpdateTranslationJobHandler : IRequestHandler<UpdateTranslationJob, bool>
    {
        private readonly ITranslationJobRepository _repository;

        public UpdateTranslationJobHandler(ITranslationJobRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTranslationJob request, CancellationToken cancellationToken)
        {
            var job = await _repository.GetByIdAsync(request.TranslationJobId);
            if (job == null) { return false; }

            var newStatus = request.NewStatus;
            bool isInvalidStatusChange = (job.Status == JobStatus.New.ToString() && newStatus == JobStatus.Completed) ||
                             job.Status == JobStatus.Completed.ToString() || newStatus == JobStatus.New;
            if (isInvalidStatusChange)
            {
                return false;
            }

            return await _repository.UpdateJob(request.TranslationJobId, request.TranslatorId, newStatus.ToString());
        }
    }
}
