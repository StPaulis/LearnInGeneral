using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GettingStartedWebAspBooks.ViewModels.Books
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonProperty("d")]
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

    }
}
