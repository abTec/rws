using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ITranslatorRepository : IRepository<Translator>
    {
        Task<bool> UpdateStatus(int translatorId, string newStatus = "");
        Task<ICollection<Translator>> GetByName(string name);
    }
}
