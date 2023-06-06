using Application.Contracts;
using Domain.Models;
using System;
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

        public override Task<TranslationJob> Create(TranslationJob entity)
        {
            entity.Status = "New"; 
            return base.Create(entity);
        }

        public Task<TranslationJob> UpdateJob(int jobId, int translatorId, string newStatus = "")
        {
            throw new NotImplementedException();
        }
    }
}
