using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ITranslationJobRepository : IRepository<TranslationJob>
    {
        Task<TranslationJob> UpdateJob(int jobId, int translatorId, string newStatus = "");
        Task<bool> AssignJob(int jobId, int transaltorId);
        Task<ICollection<TranslationJob>> GetAllJobsForTranslator(int translatorId);
    }
}