﻿using System.Security.Claims;
using System.Threading.Tasks;
using GettingStartedWebAspBooks.Models;
using GettingStartedWebAspBooks.ViewModels.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GettingStartedWebAspBooks.Data.Repositories.Users
{
    public class CurrentUser : ICurrentUser
    {
        private readonly HttpContext _httpContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private string _userId;

        public string UserId => _userId ?? (_userId = _httpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        public CurrentUser(IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<UsersViewModel> GetUserAsync()
        {
            return _mapper.Map<UsersViewModel>(await GetAppUserAsync());
        }

        public async Task<ApplicationUser> GetAppUserAsync()
        {
            return await _userManager.GetUserAsync(_httpContext.User);
        }
    }
}