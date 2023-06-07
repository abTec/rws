using Application.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TranslationJobRepository : Repository<TranslationJob>, ITranslationJobRepository
    {
        private readonly AppDbContext _context;

        public TranslationJobRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<TranslationJob> UpdateJob(int jobId, int translatorId, string newStatus = "")
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AssignJob(int jobId, int transaltorId)
        {
            var entity = await _context.TranslationJobs.FirstOrDefaultAsync(x => x.Id == jobId);
            if (entity == null) return false;

            entity.TranslatorId = transaltorId;

            _context.Update(entity);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<TranslationJob>> GetAllJobsForTranslator(int translatorId) => await Context.TranslationJobs.Where(t => t.TranslatorId == translatorId).ToListAsync();
    }
}
