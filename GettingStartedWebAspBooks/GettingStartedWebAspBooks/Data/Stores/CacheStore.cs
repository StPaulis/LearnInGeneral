using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedWebAspBooks.Data.Models;

namespace GettingStartedWebAspBooks.Data.Stores
{
    public class CacheStore : ICacheStore
    {
        public Dictionary<int, Book> Cache { get; set; }

        public CacheStore()
        {
            Cache = new Dictionary<int, Book>();
        }
       
    }
}
