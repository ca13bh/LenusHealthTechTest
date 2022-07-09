namespace LenusHealthTechTest.Repositories.Commands.CreateBook
{
    using LenusHealthTechTest.Entities.Core;
    using LenusHealthTechTest.Interfaces.Commands.CreateBook;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class CreateBookCommand : ICreateBookCommand
    {
        private readonly BookStoreContext context;
        private readonly ILogger logger;

        public CreateBookCommand(
            BookStoreContext context, 
            ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<CreateBookCommandResponse> ExecuteAsync(CreateBookCommandRequest commandRequest)
        {
            this.logger.LogInformation("Adding book to DB");

            var book = new Book
            {
                Title = commandRequest.Title,
                Price = commandRequest.Price,
                Author = commandRequest.Author
            };

            await context.AddAsync(book);

            return new CreateBookCommandResponse { Id = book.Id };
        }
    }
}
