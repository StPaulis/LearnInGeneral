using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  System.Reflection;
using  Autofac;
using Module = Autofac.Module;


namespace GettingStartedWebAspBooks.Infrastructure.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
