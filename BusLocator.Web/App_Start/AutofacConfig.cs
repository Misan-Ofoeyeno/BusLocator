using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BusLocator.Persistence.Context;
using BusLocator.Persistence.Repository.Abstract;
using BusLocator.Persistence.Repository.Concrete;
using BusLocator.Persistence.UnitofWork.Abstract;
using BusLocator.Persistence.UnitofWork.Concrete;
using BusLocator.Services.Managers;
using BusLocator.Services.Managers.Abstract;
using BusLocator.Services.Managers.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BusLocator.Web.App_Start
{
    public class AutofacConfig
    {
        public static IContainer RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            AddAPIRegistrations(builder);
            AddRegisterations(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        private static void AddAPIRegistrations(ContainerBuilder builder)
        {
            //mvc
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            //web api
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterModule<AutofacWebTypesModule>();

        }

        private static void AddRegisterations(ContainerBuilder builder)
        {
            builder.RegisterType<BusLocatorContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<UnitofWork>()
                   .As<IUnitofWork>()
                   .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                   .As<IDbFactory>()
                   .InstancePerRequest();

            builder.RegisterGeneric(typeof(BaseRepository<>))
                   .As(typeof(IBaseRepository<>))
                   .InstancePerRequest();

            builder.RegisterType<BusManager>()
                   .As<IBusManager>()
                   .InstancePerRequest();

            builder.RegisterType<Windsor>()
                   .As<IWindsor>()
                   .InstancePerRequest();
        }
    }
}