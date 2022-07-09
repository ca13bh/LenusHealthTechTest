namespace LenusHealthTechTest.Entities.Core
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public long Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }
    }
}
