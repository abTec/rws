using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TranslationManagement.Api.Controlers
{
    [ApiController]
    [Route("api/TranslatorsManagement/[action]")]
    public class TranslatorManagementController : ControllerBase
    {
        public static readonly string[] TranslatorStatuses = { "Applicant", "Certified", "Deleted" };
        private readonly IMediator mediator;
        private readonly ILogger<TranslatorManagementController> _logger;

        public TranslatorManagementController(IMediator mediator, ILogger<TranslatorManagementController> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<TranslatorDto[]> GetTranslators()
        {
            var result = await mediator.Send(new GetAllTranslators());
            return result.ToArray();
        }

        [HttpGet]
        public async Task<TranslatorDto[]> GetTranslatorsByName(string name)
        {
            var result = await mediator.Send(new GetTranslatorsByName { Name = name });

            return result.ToArray();
        }

        [HttpPost]
        public async Task<bool> AddTranslator(TranslatorDto translator) => await mediator.Send(new CreateTranslator { Translator = translator });

        [HttpPost]
        public string UpdateTranslatorStatus(int translatorId, string newStatus = "")
        {
            _logger.LogInformation("User status update request: " + newStatus + " for user " + translatorId.ToString());
            if (!TranslatorStatuses.Where(status => status == newStatus).Any())
            {
                throw new ArgumentException("unknown status");
            }

            //var job = _context.Translators.Single(j => j.Id == Translator);
            //job.Status = newStatus;
            //_context.SaveChanges();

            return "updated";
        }
    }
}