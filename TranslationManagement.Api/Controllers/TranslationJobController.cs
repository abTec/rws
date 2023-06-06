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
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly ITranslationJobRepository _repository;
        private readonly ILogger<TranslatorManagementController> _logger;

        public TranslationJobController(IMediator mediator, IMapper mapper, ITranslationJobRepository repository, ILogger<TranslatorManagementController> logger)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this._repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<TranslationJobDto[]> GetJobs()
        {
            var jobs = await mediator.Send(new GetAllTranslationJobs());
            return jobs.ToArray();
        }

        const double PricePerCharacter = 0.01;
        private void SetPrice(TranslationJobDto job)
        {
            job.Price = job.OriginalContent.Length * PricePerCharacter;
        }

        [HttpPost]
        public bool CreateJob(TranslationJobDto job)
        {
            job.Status = JobStatus.New;
            SetPrice(job);
            //_context.TranslationJobs.Add(job);
            bool success = false;
            if (success)
            {
                var notificationSvc = new UnreliableNotificationService();
                while (!notificationSvc.SendNotification("Job created: " + job.Id).Result)
                {
                }

                _logger.LogInformation("New job notification sent");
            }

            return success;
        }

        [HttpPost]
        public bool CreateJobWithFile(IFormFile file, string customer)
        {
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