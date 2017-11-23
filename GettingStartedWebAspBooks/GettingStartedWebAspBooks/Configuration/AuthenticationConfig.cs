﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStartedWebAspBooks.Configuration
{
    public class AuthenticationConfig
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int ExpiresInMinutes { get; set; }
    }
}
