using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedWebAspBooks.Data.Models;
using GettingStartedWebAspBooks.Data.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  PagedList;

namespace GettingStartedWebAspBooks.Data.Repositories.Books
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICacheStore _booksCache;

        public BooksRepository(ApplicationDbContext dbContext, ICacheStore booksCache)
        {
            _dbContext = dbContext;
            _booksCache = booksCache;
        }

        public async Task<Book> FindAsync(int id)
        {
            _booksCache.Cache.TryGetValue(id, out var book);
            if (book != null) return book;
            book = await _dbContext.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            _booksCache.Cache.Add(id, book);

            return book;
        }

        public async Task<List<Book>> FindBooksByName(string bookName)
        {
            var lst = new List<Book>();

            lst = await _dbContext.Books.Where(x => x.Title.Contains(bookName)).ToListAsync();

            return lst;
        }

        public async Task<List<Book>> FindBooksByAuthor(string authorName)
        {
            var lst = new List<Book>();
            lst = await _dbContext.Books.Where(x => x.Author.Name.Contains(authorName)).OrderBy(x => x.Title).ToListAsync();

            return lst;
        }

        public async Task<List<Book>> FindBooksByAuthor(int page, string authorName)
        {
           
           var lst = await _dbContext.Books.Where(x => x.Author.Name.Contains(authorName)).ToListAsync();

            return lst.ToPagedList(page, 2).ToList();
        }

        public Task AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            return _dbContext.SaveChangesAsync();

        }

        public int FindAuthorByName(string authorName)
        {
            var authors = _dbContext.Authors.FirstOrDefault(x => x.Name == authorName);
            if (authors != null)
            {
                return authors.Id;
            }
            else
            {
                return -1;
            }

        }

        public Author FindAuthorById(int id)
        {
            return _dbContext.Authors.FirstOrDefault(x => x.Id == id);
        }
    }
}
