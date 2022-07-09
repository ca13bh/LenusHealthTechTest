namespace LenusHealthTechTest.Interfaces.Queries
{
    using LenusHealthTechTest.Entities.Core;
    using LenusHealthTechTest.Interfaces.Core;
    using LenusHealthTechTest.Interfaces.Queries.GetBook;

    public interface IGetBookQuery : IQuery<GetBookQueryRequest ,Book>
    {
    }
}
