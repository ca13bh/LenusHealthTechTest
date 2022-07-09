namespace LenusHealthTechTest.Interfaces.Commands.DeleteBook
{
    using LenusHealthTechTest.Interfaces.Core;

    public interface IDeleteBookCommand : ICommand<DeleteBookCommandRequest, DeleteBookCommandResponse>
    {
    }
}
