using Application.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public Task<Translator> UpdateJob(int translatorId, string newStatus = "")
        {
            throw new NotImplementedException();
        }
    }
}
