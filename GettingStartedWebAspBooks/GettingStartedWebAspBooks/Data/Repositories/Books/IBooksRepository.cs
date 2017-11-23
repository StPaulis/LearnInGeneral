using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedWebAspBooks.Data.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace GettingStartedWebAspBooks.Data.Repositories.Books
{
    public interface IBooksRepository
    {
        Task<Book> FindAsync(int id);
        Task<List<Book>> FindBooksByName(string bookName);
        Task<List<Book>> FindBooksByAuthor(string authorName);
        Task<List<Book>> FindBooksByAuthor(int page, string authorName);
        Task AddBook(Book book);
        int FindAuthorByName(string name);
        Author FindAuthorById(int id);
    }
}
