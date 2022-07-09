namespace LenusHealthTechTest.Interfaces.Queries.GetBook
{
    using System.ComponentModel.DataAnnotations;

    public class GetBookQueryRequest
    {
        [Required]
        public long Id { get; set; }
    }
}
