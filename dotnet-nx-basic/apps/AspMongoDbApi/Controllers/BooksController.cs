using AspMongoDbApi.Services;
using Common.Models.asp_mongodb_api;
using Microsoft.AspNetCore.Mvc;

namespace AspMongoDbApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService)
    {
      _booksService = booksService;
    }

    [HttpGet]
    public async Task<List<Book>> Get() =>
        await _booksService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> Get([FromRoute] long id)
    {
      var book = await _booksService.GetAsync(id);

      if (book is null)
      {
        return NotFound();
      }

      return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book newBook)
    {
      await _booksService.CreateAsync(newBook);

      return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] long id,[FromBody] Book updatedBook)
    {
      var book = await _booksService.GetAsync(id);

      if (book is null)
      {
        return NotFound();
      }

      updatedBook.Id = book.Id;

      await _booksService.UpdateAsync(id, updatedBook);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
      var book = await _booksService.GetAsync(id);

      if (book is null)
      {
        return NotFound();
      }

      await _booksService.RemoveAsync(id);

      return NoContent();
    }
  }
}