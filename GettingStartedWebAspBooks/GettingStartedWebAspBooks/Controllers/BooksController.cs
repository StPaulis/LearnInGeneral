using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GettingStartedWebAspBooks.Data.Models;
using GettingStartedWebAspBooks.Data.Repositories.Books;
using GettingStartedWebAspBooks.ViewModels.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;


namespace GettingStartedWebAspBooks.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]"), AllowAnonymous]
    public class BooksController : Controller
    {
        private readonly IBooksRepository _booksRepository;


        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet("{id:min(1)}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _booksRepository.FindAsync(id);
            if (book == null) return NotFound();

            return Ok(Mapper.Map<BookViewModel>(book));
        }

        [HttpGet]
        public async Task<IActionResult> GetByName(string bookName)
        {
            var lstBooks = await _booksRepository.FindBooksByName(bookName);
            return ReturnMappedBooks(lstBooks);
        }

        [HttpGet]
        [Route("api/[controller]/GetBookByAuthor")]
        public async Task<IActionResult> GetByAuthor(string authorName)
        {
            var lstBooks = await _booksRepository.FindBooksByAuthor(authorName);
            return ReturnMappedBooks(lstBooks);
        }


        [HttpGet]
        [Route("api/[controller]/GetPagedBooksByAuthor")]
        public async Task<IActionResult> GetPagedBooksByAuthor(int page, string authorName)
        {
            var books = await _booksRepository.FindBooksByAuthor(page, authorName);

            //var viewModels = Mapper.Map<IPagedList<Book>, IPagedList<BookViewModel>>(books);

            return ReturnMappedBooks(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]BookCreateViewModel model)
        {
            var authorId = _booksRepository.FindAuthorByName(model.AuthorName);
            Author author;

            if( authorId != -1)
            {
                 author = _booksRepository.FindAuthorById(authorId);
            }
            else
            {
                author = new Author()
                {
                    Name = model.AuthorName
                };
            }

            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                Author = author,
                DateCreated = model.DateCreated
            };

            await _booksRepository.AddBook(book);

            return Ok(book);
        }

        private IActionResult ReturnMappedBooks(ICollection lst)
        {
            if (lst.Count > 0)
            {
                return Ok(Mapper.Map<List<BookViewModel>>(lst));
            }
            else
            {
                return Ok();
            }
        }
    }
}