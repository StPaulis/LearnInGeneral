using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStartedWebAspBooks.ViewModels.Books
{
    public class BookCreateViewModel
    {
        [Required, MinLength(2)]
        public string Title { get; set; }
        [MinLength(2)]
        public string Description { get; set; }
        [MinLength(2)]
        public string AuthorName { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
