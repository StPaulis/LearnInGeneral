using AutoMapper;
using GettingStartedWebAspBooks.Data.Models;
using PagedList;

namespace GettingStartedWebAspBooks.ViewModels.Books
{
    public class BookProfile : Profile
    {
        public  BookProfile()
        {

            CreateMap<BookProfile, BookViewModel>();
        }
    }
}
