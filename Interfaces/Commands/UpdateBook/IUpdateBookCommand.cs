namespace LenusHealthTechTest.Interfaces.Commands.UpdateBook
{
    using LenusHealthTechTest.Interfaces.Core;

    public interface IUpdateBookCommand : ICommand<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
    }
}
