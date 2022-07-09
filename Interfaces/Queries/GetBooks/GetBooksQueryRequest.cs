namespace LenusHealthTechTest.Interfaces.Queries.GetBooks
{
    using LenusHealthTechTest.Entities.Enum;

    public class GetBooksQueryRequest
    {
        public SortByValues? sortBy { get; set; }
    }
}
