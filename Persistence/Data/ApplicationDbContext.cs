using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Todo>(entity => {
            //     entity.HasKey(e => e.Id);
            // });
        }

    }
}
