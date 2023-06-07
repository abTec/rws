using Application.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TranslationJobRepository : Repository<TranslationJob>, ITranslationJobRepository
    {
        public TranslationJobRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> UpdateJob(int jobId, int translatorId, string newStatus = "")
        {
            var entity = await Context.TranslationJobs.FirstOrDefaultAsync(x => x.Id == jobId);
            if (entity == null) return false;

            entity.Status = newStatus;

            Context.Update(entity);
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AssignJob(int jobId, int transaltorId)
        {
            var entity = await Context.TranslationJobs.FirstOrDefaultAsync(x => x.Id == jobId);
            if (entity == null) return false;

            entity.TranslatorId = transaltorId;

            Context.Update(entity);
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<TranslationJob>> GetAllJobsForTranslator(int translatorId) => await Context.TranslationJobs.Where(t => t.TranslatorId == translatorId).ToListAsync();
    }
}
