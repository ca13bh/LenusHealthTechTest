namespace LenusHealthTechTest.StartupTasks
{
    using LenusHealthTechTest.Entities.Core;
    using LenusHealthTechTest.Interfaces.Core;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDatabaseStartupTask : IStartUpTask
    {
        public async Task Execute(BookStoreContext context)
        {
            if (!context.Books.Any())
            {
                await context.Books.AddRangeAsync(
                    new Book
                    {
                        Id = 1,
                        Author = "A. A. Milne",
                        Title = "Winnie-the-Pooh",
                        Price = 19.25M
                    },
                    new Book
                    {
                        Id = 2,
                        Author = "Jane Austen",
                        Title = "Pride and Prejudice",
                        Price = 5.49M
                    },
                    new Book
                    {
                        Id = 3,
                        Author = "William Shakespeare",
                        Title = "Romeo and Juliet",
                        Price = 6.95M
                    });
            }

            await context.SaveChangesAsync();
        }
    }
}
