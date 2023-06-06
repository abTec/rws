using Domain.Models;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ITranslationJobRepository : IRepository<TranslationJob>
    {
        Task<TranslationJob> UpdateJob(int jobId, int translatorId, string newStatus = "");
    }
}