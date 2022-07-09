namespace LenusHealthTechTest.Repositories.Commands.CreateBook
{
    using LenusHealthTechTest.Entities.Core;
    using LenusHealthTechTest.Interfaces.Commands.DeleteBook;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class DeleteBookCommand : IDeleteBookCommand
    {
        private readonly BookStoreContext context;
        private readonly ILogger logger;

        public DeleteBookCommand(
            BookStoreContext context, 
            ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<DeleteBookCommandResponse> ExecuteAsync(DeleteBookCommandRequest commandRequest)
        {
            this.logger.LogInformation($"Deleting book with Id : {commandRequest.Id} from DB");

            var book = await this.context.Books.FindAsync(commandRequest.Id);
            if (book is null)
            {
                this.logger.LogInformation($"Book with Id: {commandRequest.Id} not found");
                return null;
            }

            this.context.Books.Remove(book);

            return new DeleteBookCommandResponse { };
        }
    }
}
