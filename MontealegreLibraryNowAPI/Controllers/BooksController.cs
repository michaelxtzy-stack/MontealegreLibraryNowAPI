using MontealegreLibraryNowAPI.Models;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace MontealegreLibraryNowAPI.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Legend of the Northern Blade",
                Author = "Woo-Gak",
                Genre = "action, Murim, Fiction",
                Available = true,
                PublishedYear = 0,
            },


            new Book
            {
                Id = 2,
                Title = "leviathan",
                Author = "Lee Gyuntak",
                Genre = "action, Murim, Fiction",
                Available = true,
                PublishedYear = 0,
            }

        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                status = "success",
                data = books,
                message = "book retieved"

            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound(new
                {
                    Status = "error",
                    data = (object?)null,
                    message = "book retrieved"
                });

            }
            return Ok(new
            {
                Status = "error",
                data = (object?)null,
                message = "book retrieved"
            });
        }
        [HttpPost]
        public IActionResult Create([FromBody] Book newBook)
        {
            newBook.Id = books.Count + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetById),
                new { id = newBook.Id },
                new
                {
                    status = "Success",
                    data = newBook,
                    message = "Book Created"
                });



        }
        [HttpPut("{id}")]

        public IActionResult Update(int id,
            [FromBody] Book updateBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return NotFound(
                    new
                    {
                        status = "error",
                        data = (object?)null,
                        message = "Book Not Found."
                    });
            book.Title = updateBook.Title;
            book.Author = updateBook.Author;
            book.Genre = updateBook.Genre;
            book.PublishedYear = updateBook.PublishedYear;

            return Ok(new
            {
                status = "success",
                data = book,
                message = "Book updated."
            });
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            return NotFound(new
            {
                status = "error",
                data = (object?)null,
                message = "Book Not found."
            });

            books.Remove(book);
            return Ok(new
            {
                status = "success",
                data = books,
                message = "Book Deleted."

            });



        }
    }
}




       