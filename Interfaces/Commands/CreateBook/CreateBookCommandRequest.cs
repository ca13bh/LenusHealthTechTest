namespace LenusHealthTechTest.Interfaces.Commands.CreateBook
{
    using System.ComponentModel.DataAnnotations;

    public class CreateBookCommandRequest
    {
        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }
    }
}
