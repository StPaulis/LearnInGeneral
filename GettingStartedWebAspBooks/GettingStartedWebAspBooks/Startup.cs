using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedWebAspBooks.Application.Policies;
using GettingStartedWebAspBooks.Configuration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GettingStartedWebAspBooks.Data;
using GettingStartedWebAspBooks.Models;
using GettingStartedWebAspBooks.Extensions;
using GettingStartedWebAspBooks.Infrastructure.Extensions.Auth;
using GettingStartedWebAspBooks.Data.Repositories;
using GettingStartedWebAspBooks.ViewModels.Users;
using GettingStartedWebAspBooks.Infrastructure.Mappings;
using  AutoMapper;
using GettingStartedWebAspBooks.Infrastructure;
using GettingStartedWebAspBooks.Infrastructure.Filters;
using Swashbuckle.AspNetCore.Swagger;
using GettingStartedWebAspBooks.Infrastructure.Modules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace GettingStartedWebAspBooks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.Configure<AuthenticationConfig>(Configuration.GetSection("Authentication"));


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDomainAuthentication(Configuration.GetSection("Authentication"))
                .AddDomainAuthorization<AuthServerPolicies>();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            //services.AddTransient<IUsersRepository,UsersRepository>();



            services.AddAutoMapper()
            .AddSwaggerDocumentation();

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
                options.Filters.Add(new ValidateModelStateFilter());
            });


            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<StoreModule>();
            builder.RegisterModule<ServiceModule>();
            this.Container = builder.Build();

            return new AutofacServiceProvider(this.Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
                app.UseSwaggerDocumentation();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
