namespace LenusHealthTechTest.Controllers.ControllerRequestModels.GetBook
{
    using LenusHealthTechTest.Interfaces.Queries.GetBook;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class GetBookRequestModel
    {
        [FromRoute]
        [Required]
        public long Id { get; set; }

        public GetBookQueryRequest ToQueryRequest()
        {
            return new GetBookQueryRequest 
            { 
                Id = this.Id
            };
        }
    }
}
