using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  GettingStartedWebAspBooks.Models;
using  AutoMapper;
using GettingStartedWebAspBooks.Infrastructure;


namespace GettingStartedWebAspBooks.ViewModels.Users
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<ApplicationUser, UsersViewModel>();
        }
    }
}
