using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Module = Autofac.Module;

namespace GettingStartedWebAspBooks.Infrastructure.Modules
{
    public class StoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Store"))
                .AsImplementedInterfaces()
                //.InstancePerLifetimeScope();
                .SingleInstance();
        }
    }
}
