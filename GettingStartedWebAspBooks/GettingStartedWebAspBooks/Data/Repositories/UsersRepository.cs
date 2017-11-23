﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GettingStartedWebAspBooks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GettingStartedWebAspBooks.Data.Repositories
{
    public interface IUsersRepository
    {
        Task<int> CountAsync();
        Task<ApplicationUser> GetByEmail(string email);
        Task<ApplicationUser> GetOne();
        Task<IdentityResult> AddPolicyToUser(string email, string policy);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }


        public Task<int> CountAsync()
        {
            return _db.Users.CountAsync();
        }

        public Task<ApplicationUser> GetByEmail(string email)
        {
            return _db.Users.Where(c => c.Email == email).FirstOrDefaultAsync();
        }

        public Task<ApplicationUser> GetOne()
        {
            return _db.Users.FirstOrDefaultAsync();
        }

        public async Task<IdentityResult> AddPolicyToUser(string email, string policy)
        {
            var user = await GetByEmail(email);
            if (user == null) return null;

            var claim = new Claim(policy,"allow");

            return await _userManager.AddClaimAsync(user, claim);
        }
    }
}
