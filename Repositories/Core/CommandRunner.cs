namespace LenusHealthTechTest.Repositories.Core
{
    using LenusHealthTechTest.Interfaces.Core;
    using System.Threading.Tasks;

    public class CommandRunner : ICommandRunner
    {
        private readonly BookStoreContext context;

        public CommandRunner(BookStoreContext context)
        {
            this.context = context;
        }

        public async Task<TResponse> ExecuteAsync<TRequest, TResponse>(ICommand<TRequest, TResponse> cmd, TRequest request)
        {
            var result = await cmd.ExecuteAsync(request);

            await context.SaveChangesAsync();

            return result;
        }
    }
}
