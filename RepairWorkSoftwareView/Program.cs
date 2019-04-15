using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareServiceImplementList;
using ServiceImplementsDatabase;
using ServiceImplementsDatabase.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace RepairWorkSoftwareView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainForm>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICustomerService, CustomerServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMaterialService, MaterialServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWorkService, WorkServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStockService, StockServiceDB>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<DbContext, AbstractDbContext>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
