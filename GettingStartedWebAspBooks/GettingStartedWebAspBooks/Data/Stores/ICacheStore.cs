using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedWebAspBooks.Data.Models;

namespace GettingStartedWebAspBooks.Data.Stores
{
    public  interface ICacheStore
    {
        Dictionary<int, Book> Cache { get; set; }
    }
}
