using System;
using Microsoft.Extensions.DependencyInjection;

namespace GettingStartedWebAspBooks.Infrastructure.Extensions.Auth
{
    public static class AuthorizationServiceExtensions
    {
        public static IServiceCollection AddDomainAuthorization<T>(this IServiceCollection services)
            where T : ICustomPolicyBuilder
        {
            if(!(Activator.CreateInstance<T>() is ICustomPolicyBuilder instance)) 
                throw new ArgumentException("Value of T should be type of ICustomPolicyBuilder");

            services.AddAuthorization(o =>
            {
                foreach (var policy in instance.GetPolicies())
                {
                    o.AddPolicy(policy.Key, policy.Value);
                }
            });

            return services;
        }
    }
}
