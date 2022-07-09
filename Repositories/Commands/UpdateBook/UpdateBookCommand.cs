namespace LenusHealthTechTest.Repositories.Commands.UpdateBook
{
    using LenusHealthTechTest.Interfaces.Commands.UpdateBook;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class UpdateBookCommand : IUpdateBookCommand
    {
        private readonly BookStoreContext context;
        private readonly ILogger logger;

        public UpdateBookCommand(
            BookStoreContext context, 
            ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<UpdateBookCommandResponse> ExecuteAsync(UpdateBookCommandRequest commandRequest)
        {
            this.logger.LogInformation($"Updating book with Id: {commandRequest.Id}");

            var book = await this.context.Books.FindAsync(commandRequest.Id);
            if (book is null)
            {
                this.logger.LogInformation($"Book with Id: {commandRequest.Id} not found");
                return null;
            }

            book.Author = commandRequest.Author;
            book.Price = commandRequest.Price;
            book.Title = commandRequest.Title;

            context.Books.Update(book);

            return new UpdateBookCommandResponse { };
        }
    }
}
