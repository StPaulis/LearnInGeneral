using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GettingStartedWebAspBooks.Infrastructure.Extensions.Auth
{
    public static class AuthenticationServiceExtensions
    {
        public static IServiceCollection AddDomainAuthentication(this IServiceCollection services,IConfiguration configuration)
        {
            var symmetricKeyAsBase64 = configuration["Secret"];
            var keyBiteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var singingKey = new SymmetricSecurityKey(keyBiteArray);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = singingKey,
                ValidateIssuer = true,
                ValidIssuer = configuration["Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1)
            };

            services.AddAuthentication()
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = true;
                    o.SaveToken = true;
                    o.TokenValidationParameters = tokenValidationParameters;
                });

            return services;
        }
    }
}
