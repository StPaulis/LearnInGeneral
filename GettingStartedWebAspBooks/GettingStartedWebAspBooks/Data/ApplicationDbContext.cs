using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedWebAspBooks.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GettingStartedWebAspBooks.Models;

namespace GettingStartedWebAspBooks.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public  DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
