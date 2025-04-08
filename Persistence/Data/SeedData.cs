using Domain.Entities;
using Domain.Enum;
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
            context.Persons.AddRange(
                new Person("John", "Doe", new DateTime(1990, 1, 1),GenderType.Female,"New York")
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Person("Nguyen", "Vu", new DateTime(2003, 1, 1),GenderType.Male,"Quang Ninh")
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Person("Vu", "The", new DateTime(1990, 1, 1),GenderType.Female,"Ha Noi")
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Person("Tran", "Quan", new DateTime(1990, 1, 1),GenderType.Female,"Da Nang")
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
            context.SaveChanges();
        }
    }
}
