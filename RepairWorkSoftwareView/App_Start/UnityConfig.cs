using System;
using System.Data.Entity;
using RepairWorkSoftwareDAL.Interface;
using ServiceImplementsDatabase;
using ServiceImplementsDatabase.Implementations;
using Unity;
using Unity.Lifetime;

namespace RepairWorkSoftwareView
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container.RegisterType<ICustomerService, CustomerServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IMaterialService, MaterialServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IWorkService, WorkServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IMainService, MainServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IStockService, StockServiceDB>(new HierarchicalLifetimeManager());
            container.RegisterType<IReportService, ReportServiceDB>(new HierarchicalLifetimeManager());

            container.RegisterType<DbContext, AbstractDbContext>(new HierarchicalLifetimeManager());
        }
    }
}