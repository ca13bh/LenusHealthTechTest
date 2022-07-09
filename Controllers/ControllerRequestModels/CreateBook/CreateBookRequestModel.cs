namespace LenusHealthTechTest.Controllers.ControllerRequestModels.CreateBook
{
    using LenusHealthTechTest.Interfaces.Commands.CreateBook;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class CreateBookRequestModel
    {
        [FromBody]
        public RequestBody Body { get; set; }

        public CreateBookCommandRequest ToCommandRequest()
        {
            return new CreateBookCommandRequest
            {
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
