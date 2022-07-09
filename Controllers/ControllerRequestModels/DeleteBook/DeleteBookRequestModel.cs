namespace LenusHealthTechTest.Controllers.ControllerRequestModels.DeleteBook
{
    using LenusHealthTechTest.Interfaces.Commands.DeleteBook;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class DeleteBookRequestModel
    {
        [FromRoute]
        [Required]
        public long Id { get; set; }

        public DeleteBookCommandRequest ToCommandRequest()
        {
            return new DeleteBookCommandRequest
            { 
                Id = this.Id
            };
        }
    }
}
