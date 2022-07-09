namespace LenusHealthTechTest.Interfaces.Core
{
    using System.Threading.Tasks;

    public interface IQuery<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
