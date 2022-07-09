namespace LenusHealthTechTest.Repositories.Core
{
    using LenusHealthTechTest.Interfaces.Core;
    using System.Threading.Tasks;

    public class QueryRunner : IQueryRunner
    {
        private readonly BookStoreContext context;

        public QueryRunner(BookStoreContext context)
        {
            this.context = context;
        }

        public async Task<TResponse> ExecuteAsync<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest request)
        {
            var result = await query.ExecuteAsync(request);

            return result;
        }
    }

}
