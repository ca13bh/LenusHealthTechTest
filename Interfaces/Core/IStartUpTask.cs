namespace LenusHealthTechTest.Interfaces.Core
{
    using System.Threading.Tasks;

    public interface IStartUpTask
    {
        Task Execute(BookStoreContext context);
    }
}
