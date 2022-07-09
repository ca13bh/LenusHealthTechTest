namespace LenusHealthTechTest.Repositories.Queries.GetBooks
{
    using LenusHealthTechTest.Entities.Core;
    using LenusHealthTechTest.Interfaces.Queries;
    using LenusHealthTechTest.Interfaces.Queries.GetBook;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class GetBookQuery : IGetBookQuery
    {
        private readonly BookStoreContext context;
        private readonly ILogger logger;

        public GetBookQuery(
            BookStoreContext context,
            ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<Book> ExecuteAsync(GetBookQueryRequest request)
        {
            this.logger.LogInformation($"Getting book by Id: {request.Id}");
            var book = await this.context.Books.FindAsync(request.Id);

            return book;
        }
    }
}
