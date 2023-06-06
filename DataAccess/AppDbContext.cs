using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TranslationJob> TranslationJobs { get; set; }
        public DbSet<Translator> Translators { get; set; }
    }
}