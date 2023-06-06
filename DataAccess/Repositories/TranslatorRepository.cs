using Application.Contracts;
using Domain.Models;
using System;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TranslatorRepository : Repository<Translator>, ITranslatorRepository
    {
        public TranslatorRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Translator> UpdateJob(int translatorId, string newStatus = "")
        {
            throw new NotImplementedException();
        }
    }
}
