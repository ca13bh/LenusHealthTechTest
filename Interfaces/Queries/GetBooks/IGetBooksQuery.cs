namespace LenusHealthTechTest.Interfaces.Queries.GetBooks
{
    using LenusHealthTechTest.Entities.Core;
    using LenusHealthTechTest.Interfaces.Core;
    using System.Collections.Generic;

    public interface IGetBooksQuery : IQuery<GetBooksQueryRequest, IEnumerable<Book>>
    {
    }
}
