using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStartedWebAspBooks.ViewModels.Users
{
    public class UsersEditViewModel
    {
        [Required,Range(1,100)]
        public int Id { get; set; }

        [Required, DataType(DataType.EmailAddress),MinLength(6)]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public int UserName { get; set; }
    }
}
