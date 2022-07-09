namespace LenusHealthTechTest.Interfaces.Commands.CreateBook
{
    using System.ComponentModel.DataAnnotations;

    public class CreateBookCommandResponse
    {
        [Required]
        public long Id { get; set; }
    }
}
