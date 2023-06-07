using Application.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TranslatorRepository : Repository<Translator>, ITranslatorRepository
    {
        public TranslatorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Translator>> GetByName(string name) => await Context.Translators.Where(t => t.Name == name).ToListAsync();

        public async Task<bool> UpdateStatus(int translatorId, string newStatus = "")
        {
            var translator = await GetByIdAsync(translatorId);
            if (translator == null)
            {
                return false;
            }

            translator.Status = newStatus;

            Context.Update(translator);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
