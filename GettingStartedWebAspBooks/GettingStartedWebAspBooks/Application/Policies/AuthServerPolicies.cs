using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using GettingStartedWebAspBooks.Infrastructure.Extensions.Auth;


namespace GettingStartedWebAspBooks.Application.Policies
{
    public class AuthServerPolicies : ICustomPolicyBuilder
    {
        public const string RolePermissionsPolicy = "RolePermissionsPolicy";


        public Dictionary<string, Action<AuthorizationPolicyBuilder>> GetPolicies() =>
            new Dictionary<string, Action<AuthorizationPolicyBuilder>>
            {
                {RolePermissionsPolicy, policy => policy.RequireClaim("RolePermissionsChange", "allow")}
            };
    }
}



