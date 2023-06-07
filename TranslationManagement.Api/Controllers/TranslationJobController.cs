using Application.Contracts;
using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.Models;
using External.ThirdParty.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TranslationManagement.Api.Controlers;

namespace TranslationManagement.Api.Controllers
{
    [ApiController]
    [Route("api/jobs/[action]")]
    public class TranslationJobController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly INotificationService _notificationService;
        private readonly IFileProcessor _fileProcessor;
        private readonly ILogger<TranslatorManagementController> _logger;

        public TranslationJobController(IMediator mediator, INotificationService notificationService, IFileProcessor fileProcessor, ILogger<TranslatorManagementController> logger)
        {
            _mediator = mediator;
            _notificationService = notificationService;
            _fileProcessor = fileProcessor;
            _logger = logger;
        }

        [HttpGet]
        public async Task<TranslationJobDto[]> GetJobs()
        {
            var jobs = await _mediator.Send(new GetAllTranslationJobs());
            return jobs.ToArray();
        }

        [HttpPost]
        public async Task<bool> CreateJob(TranslationJobDto job)
        {
            var result = await _mediator.Send(new CreateTranslationJob { Model = job });

            bool success = false;
            if (success)
            {
                try
                {
                    while (!await _notificationService.SendNotification("Job created: " + job.Id))
                    {
                    }
                }
                catch (Exception)
                {

                    _logger.LogInformation($"OOPS implementation of {nameof(INotificationService)} is unreliable");
                }

                _logger.LogInformation("New job notification sent");
            }

            return success;
        }

        [HttpPost]
        public async Task<bool> CreateJobWithFile(IFormFile file, string customer)
        {
            var (content, customerName) = await _fileProcessor.ProcessFileAsync(file, customer);
            var newJob = new TranslationJobDto
            {
                OriginalContent = content,
                TranslatedContent = string.Empty,
                CustomerName = customerName,
            };

            return await CreateJob(newJob);
        }

        [HttpPost]
        public string UpdateJobStatus(int jobId, int translatorId, JobStatus newStatus)
        {
            //_logger.LogInformation("Job status update request received: " + newStatus + " for job " + jobId.ToString() + " by translator " + translatorId);
            //if (!typeof(JobStatuses).GetProperties().Any(prop => prop.Name == newStatus))
            //{
            //    return "invalid status";
            //}

            //var job = _context.TranslationJobs.Single(j => j.Id == jobId);

            //bool isInvalidStatusChange = (job.Status == JobStatuses.New && newStatus == JobStatuses.Completed) ||
            //                             job.Status == JobStatuses.Completed || newStatus == JobStatuses.New;
            //if (isInvalidStatusChange)
            //{
            //    return "invalid status change";
            //}

            //job.Status = newStatus;
            //_context.SaveChanges();
            return "updated";
        }
    }
}