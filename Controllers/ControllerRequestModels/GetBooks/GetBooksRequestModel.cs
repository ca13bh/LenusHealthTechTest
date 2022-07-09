namespace LenusHealthTechTest.Controllers.ControllerRequestModels.GetBooks
{
    using LenusHealthTechTest.Entities.Enum;
    using LenusHealthTechTest.Interfaces.Queries.GetBooks;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class GetBooksRequestModel
    {
        [FromQuery]
        public SortByValues? SortBy { get; set; }

        public GetBooksQueryRequest ToQueryRequest()
        {
            return new GetBooksQueryRequest 
            { 
                sortBy = this.SortBy
            };
        }
    }
}
