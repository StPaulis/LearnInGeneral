using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GettingStartedWebAspBooks.Infrastructure.Extensions.Auth
{
    public interface ICustomPolicyBuilder
    {
        Dictionary<string, Action<AuthorizationPolicyBuilder>> GetPolicies();
    }
}
