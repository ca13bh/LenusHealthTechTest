namespace LenusHealthTechTest.Interfaces.Core
{
    using System.Threading.Tasks;

    public interface ICommandRunner
    {
        Task<TResponse> ExecuteAsync<TRequest, TResponse>(ICommand<TRequest, TResponse> cmd, TRequest request);
    }
}
