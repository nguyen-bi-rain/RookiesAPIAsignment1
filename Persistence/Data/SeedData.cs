
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            // Look for any Todos already in the database.
            if (context.Todos.Any())
            {
                return;   // DB has been seeded
            }

            context.Todos.AddRange(
                new Todo("Task 1", "Description for Task 1")
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Todo("Task 2", "Description for Task 2")
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Todo("Task 3", "Description for Task 3")
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            context.SaveChanges();
        }
    }
}
