using Application.Contracts;
using Application.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.CommandHandlers
{
    public class AssignJobHandler : IRequestHandler<AssignJob, bool>
    {
        private readonly ITranslationJobRepository _jobRepository;
        private readonly ITranslatorRepository _translatorRepository;

        public AssignJobHandler(ITranslationJobRepository jobRepository, ITranslatorRepository translatorRepository)
        {
            _jobRepository = jobRepository;
            _translatorRepository = translatorRepository;
        }

        public async Task<bool> Handle(AssignJob request, CancellationToken cancellationToken)
        {
            // this is just an illustration of possible approaches
            // we can handle/validate existing job and/or translation here
            // 1. return false 2. throw exception.
            // Another and perhaps the best approach is keep the check within Repository
            // Because we are calling GetByIdAsync twice in golden way.
            var job = await _jobRepository.GetByIdAsync(request.JobId);
            if (job == null)
            {
                return false;
            }
            _ = await _translatorRepository.GetByIdAsync(request.TranslatorId) ?? throw new InvalidOperationException($"Transaltor with Id {request.TranslatorId} does not exist!");

            return await _jobRepository.AssignJob(request.JobId, request.TranslatorId);
        }
    }
}
