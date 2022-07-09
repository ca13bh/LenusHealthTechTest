// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace LenusHealthTechTest.Controllers
{
    using LenusHealthTechTest.Controllers.ControllerRequestModels.CreateBook;
    using LenusHealthTechTest.Controllers.ControllerRequestModels.DeleteBook;
    using LenusHealthTechTest.Controllers.ControllerRequestModels.GetBook;
    using LenusHealthTechTest.Controllers.ControllerRequestModels.GetBooks;
    using LenusHealthTechTest.Controllers.ControllerRequestModels.UpdateBook;
    using LenusHealthTechTest.Entities.Core;
    using LenusHealthTechTest.Interfaces.Commands.CreateBook;
    using LenusHealthTechTest.Interfaces.Commands.DeleteBook;
    using LenusHealthTechTest.Interfaces.Commands.UpdateBook;
    using LenusHealthTechTest.Interfaces.Core;
    using LenusHealthTechTest.Interfaces.Queries;
    using LenusHealthTechTest.Interfaces.Queries.GetBooks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly ICommandRunner commandRunner;
        private readonly IQueryRunner queryRunner;
        private readonly ICreateBookCommand createBookCommand;
        private readonly IGetBookQuery getBookQuery;
        private readonly IGetBooksQuery getBooksQuery;
        private readonly IUpdateBookCommand updateBookCommand;
        private readonly IDeleteBookCommand deleteBookCommand;

        public BooksController(
            ILogger logger,
            ICommandRunner commandRunner,
            IQueryRunner queryRunner,
            ICreateBookCommand createBookCommand,
            IGetBookQuery getBookQuery,
            IGetBooksQuery getBooksQuery,
            IUpdateBookCommand updateBookCommand,
            IDeleteBookCommand deleteBookCommand)
        {
            this.logger = logger;
            this.commandRunner = commandRunner;
            this.createBookCommand = createBookCommand;
            this.queryRunner = queryRunner;
            this.getBookQuery = getBookQuery;
            this.getBooksQuery = getBooksQuery;
            this.updateBookCommand = updateBookCommand;
            this.deleteBookCommand = deleteBookCommand;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get(GetBooksRequestModel request)
        {
            var result = await this.queryRunner.ExecuteAsync(this.getBooksQuery, request.ToQueryRequest());
            return result.ToList();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(GetBookRequestModel request)
        {
            var result = await this.queryRunner.ExecuteAsync(this.getBookQuery, request.ToQueryRequest());
            
            if (result is null)
            {
                this.logger.LogInformation($"Book with Id: {request.Id} was not found.");
                return NotFound();
            }
            else
            {
                return result;
            }

        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateBookRequestModel request)
        {
            var result = await this.commandRunner.ExecuteAsync(this.createBookCommand, request.ToCommandRequest());
            return CreatedAtAction("Get", new { id = result.Id }, result);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateBookRequestModel request)
        {
            var result = await this.commandRunner.ExecuteAsync(this.updateBookCommand, request.ToCommandRequest());

            if (result is null)
            {
                this.logger.LogInformation($"Book with Id: {request.Id} not found");
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        // DELETE api/<BooksControllerv2>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteBookRequestModel request)
        {
            var result = await this.commandRunner.ExecuteAsync(this.deleteBookCommand, request.ToCommandRequest());

            if (result is null)
            {
                this.logger.LogInformation($"Book with Id: {request.Id} not found");
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
