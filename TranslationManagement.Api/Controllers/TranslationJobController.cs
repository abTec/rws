using Application.Contracts;
using Application.Models;
using External.ThirdParty.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Xml.Linq;
using TranslationManagement.Api.Controlers;

namespace TranslationManagement.Api.Controllers
{
    [ApiController]
    [Route("api/jobs/[action]")]
    public class TranslationJobController : ControllerBase
    {
        static class JobStatuses
        {
            internal static readonly string New = "New";
            internal static readonly string Inprogress = "InProgress";
            internal static readonly string Completed = "Completed";
        }

        private readonly ITranslationJobRepository _repository;
        private readonly ILogger<TranslatorManagementController> _logger;

        public TranslationJobController(ITranslationJobRepository repository, ILogger<TranslatorManagementController> logger)
        {
            this._repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public TranslationJobDto[] GetJobs()
        {
            var s = this._repository.GetAll();

            return null;
        }

        const double PricePerCharacter = 0.01;
        private void SetPrice(TranslationJobDto job)
        {
            job.Price = job.OriginalContent.Length * PricePerCharacter;
        }

        [HttpPost]
        public bool CreateJob(TranslationJobDto job)
        {
            job.Status = "New";
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
        public string UpdateJobStatus(int jobId, int translatorId, string newStatus = "")
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