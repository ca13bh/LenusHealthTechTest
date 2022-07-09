namespace LenusHealthTechTest.Interfaces.Core
{
    using System.Threading.Tasks;

    public interface IQueryRunner
    {
        Task<TResponse> ExecuteAsync<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest request);
    }
}
