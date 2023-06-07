using Application.Contracts;
using Application.CQRS.Queries;
using Application.Models;
using AutoMapper;
using External.ThirdParty.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TranslationManagement.Api.Controlers;

namespace TranslationManagement.Api.Controllers
{
    [ApiController]
    [Route("api/jobs/[action]")]
    public class TranslationJobController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly ILogger<TranslatorManagementController> _logger;

        public TranslationJobController(IMediator mediator, IMapper mapper, INotificationService notificationService, ILogger<TranslatorManagementController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _notificationService = notificationService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<TranslationJobDto[]> GetJobs()
        {
            var jobs = await _mediator.Send(new GetAllTranslationJobs());
            return jobs.ToArray();
        }

        const double PricePerCharacter = 0.01;
        private void SetPrice(TranslationJobDto job)
        {
            job.Price = job.OriginalContent.Length * PricePerCharacter;
        }

        [HttpPost]
        public async Task<bool> CreateJob(TranslationJobDto job)
        {
            job.Status = JobStatus.New;
            SetPrice(job);
            //_context.TranslationJobs.Add(job);
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

                    _logger.LogInformation($"OOPs implementation of {nameof(INotificationService)} is unreliable");
                }

                _logger.LogInformation("New job notification sent");
            }

            return success;
        }

        [HttpPost]
        public bool CreateJobWithFile(IFormFile file, string customer)
        {
            // todo IFileProcessoreaa
            var reader = new StreamReader(file.OpenReadStream());
            string content;

            if (file.FileName.EndsWith(".txt"))
            {
                content = reader.ReadToEnd();
            }
            else if (file.FileName.EndsWith(".xml"))
            {
                var xdoc = XDocument.Parse(reader.ReadToEnd());
                content = xdoc.Root.Element("Content").Value;
                customer = xdoc.Root.Element("Customer").Value.Trim();
            }
            else
            {
                throw new NotSupportedException("unsupported file");
            }

            var newJob = new TranslationJobDto()
            {
                OriginalContent = content,
                TranslatedContent = "",
                CustomerName = customer,
            };

            SetPrice(newJob);

            return CreateJob(newJob);
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