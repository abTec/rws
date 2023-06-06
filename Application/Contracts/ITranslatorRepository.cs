using Domain.Models;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ITranslatorRepository : IRepository<Translator>
    {
        Task<Translator> UpdateJob(int translatorId, string newStatus = "");
    }
}
