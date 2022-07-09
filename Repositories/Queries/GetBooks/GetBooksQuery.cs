namespace LenusHealthTechTest.Repositories.Queries.GetBooks
{
    using LenusHealthTechTest.Entities.Core;
    using LenusHealthTechTest.Interfaces.Queries.GetBooks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetBooksQuery : IGetBooksQuery
    {
        private readonly BookStoreContext context;
        private readonly ILogger logger;

        public GetBooksQuery(
            BookStoreContext context,
            ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<IEnumerable<Book>> ExecuteAsync(GetBooksQueryRequest request)
        {
            this.logger.LogInformation("Getting all books");
            List<Book> books = new List<Book>();

            if (request.sortBy.HasValue)
            {
                books = await this.context.Books.OrderBy(x => EF.Property<object>(x, request.sortBy.Value.ToString())).ToListAsync();
            }
            else
            {
                books = await this.context.Books.ToListAsync();
            }

            return books;
        }
    }
}
