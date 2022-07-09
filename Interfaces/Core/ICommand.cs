namespace LenusHealthTechTest.Interfaces.Core
{
    using System.Threading.Tasks;

    public interface ICommand<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
