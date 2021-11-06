using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Orm.DataBase.Config;

namespace Orm.DataBase
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }
        // Add DbSet's / DataBase tables
        public DbSet<ModelDemo> ModelDemos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new ModelDemoConfig(builder.Entity<ModelDemo>());
        }
    }
}