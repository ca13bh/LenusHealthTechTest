namespace LenusHealthTechTest.Interfaces.Commands.UpdateBook
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateBookCommandRequest
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }
    }
}
