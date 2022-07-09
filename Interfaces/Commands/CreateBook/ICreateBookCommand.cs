namespace LenusHealthTechTest.Interfaces.Commands.CreateBook
{
    using LenusHealthTechTest.Entities.Core;
    using LenusHealthTechTest.Interfaces.Core;

    public interface ICreateBookCommand : ICommand<CreateBookCommandRequest, CreateBookCommandResponse>
    {
    }
}
