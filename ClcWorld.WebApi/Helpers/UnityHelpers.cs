using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using ClcWorld.Entities.Context;
using log4net;
using Microsoft.Practices.Unity;
using ClcWorld.Service.IService;

namespace ClcWorld.WebApi.Helpers
{
    public class UnityHelpers
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //private static readonly Type[] EmptyTypes = new Type[0];

        public static IEnumerable<Type> GetTypesWithCustomAttribute<T>(Assembly[] assemblies)
        {
            return from assembly in assemblies
                   from type in assembly.GetTypes()
                   where type.GetCustomAttributes(typeof(T), true).Length > 0
                   select type;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            Log.Info("Configure Unity register types.");

            // AddOrUpdate your register logic here...
            //var myAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("your_assembly_Name")).ToArray();

            // Explicit types registration: container.RegisterType(typeof (Startup));
            container.RegisterType<IClcWorldContext, ClcWorldContext>(new HierarchicalLifetimeManager());
           

            // Convention to resolve dependencies
            //container.RegisterTypes(
            //    AllClasses.FromAssemblies(typeof(Service.ServiceBase.Service).Assembly),
            //    WithMappings.FromMatchingInterface,
            //    WithName.Default,
            //    WithLifetime.Custom<HierarchicalLifetimeManager>
            //);

            container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(ICarService).Assembly),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Custom<HierarchicalLifetimeManager>
                );

        }

        #region Unity Container

        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        #endregion
    }
}