using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Autofac;
using GettingStartedWebAspBooks.Data.Repositories.Users;
using GettingStartedWebAspBooks.Models;
using Microsoft.AspNetCore.Identity;
using Module = Autofac.Module;

namespace GettingStartedWebAspBooks.Infrastructure.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterType<PasswordHasher<ApplicationUser>>().As<IPasswordHasher<ApplicationUser>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CurrentUser>().As<ICurrentUser>();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            //.InstancePerLifetimeScope();
        }
    }
}
