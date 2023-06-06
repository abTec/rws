using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace TranslationManagement.Api.Controlers
{
    [ApiController]
    [Route("api/TranslatorsManagement/[action]")]
    public class TranslatorManagementController : ControllerBase
    {


        public static readonly string[] TranslatorStatuses = { "Applicant", "Certified", "Deleted" };

        private readonly ILogger<TranslatorManagementController> _logger;
        

        public TranslatorManagementController(IServiceScopeFactory scopeFactory, ILogger<TranslatorManagementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public TranslatorDto[] GetTranslators()
        {
            return null;
        }

        [HttpGet]
        public TranslatorDto[] GetTranslatorsByName(string name)
        {
            return null;/*_context.Translators.Where(t => t.Name == name).ToArray();*/
        }

        [HttpPost]
        public bool AddTranslator(TranslatorDto translator)
        {
            return false;
            //_context.Translators.Add(translator);
            //return _context.SaveChanges() > 0;
        }

        [HttpPost]
        public string UpdateTranslatorStatus(int Translator, string newStatus = "")
        {
            _logger.LogInformation("User status update request: " + newStatus + " for user " + Translator.ToString());
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