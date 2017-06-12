using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Tadda.Data;
using Tadda.Data.Infrastructure;
using Tadda.Data.Repository;
using Tadda.Model.Entities;
using Tadda.Service;
using Tadda.Service.Implementation;

namespace Tadda.WebApi.App_Start
{
    public class AutofacWebapiConfig
    {

        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<TaddaDataContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<DatabaseFactory>()
                .As<IDatabaseFactory>()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(AddressRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(typeof(CompanyService).Assembly)
           .Where(t => t.Name.EndsWith("Service"))
           .AsImplementedInterfaces().InstancePerRequest();


            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TaddaDataContext())))
              .As<UserManager<ApplicationUser>>().InstancePerRequest();


            Container = builder.Build();

            return Container;
        }

    }
}