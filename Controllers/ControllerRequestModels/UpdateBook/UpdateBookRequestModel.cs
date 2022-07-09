namespace LenusHealthTechTest.Controllers.ControllerRequestModels.UpdateBook
{
    using LenusHealthTechTest.Interfaces.Commands.UpdateBook;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class UpdateBookRequestModel
    {
        [Required]
        [FromRoute]
        public long Id { get; set; }
        
        [FromBody]
        public RequestBody Body { get; set; }

        public UpdateBookCommandRequest ToCommandRequest()
        {
            return new UpdateBookCommandRequest
            {
                Id = this.Id,
                Title = this.Body.Title,
                Author = this.Body.Author,
                Price = this.Body.Price,
            };
        }

        public class RequestBody
        {
            [Required]
            public string Title { get; set; }

            public string Author { get; set; }

            public decimal Price { get; set; }
        }
    }
}
