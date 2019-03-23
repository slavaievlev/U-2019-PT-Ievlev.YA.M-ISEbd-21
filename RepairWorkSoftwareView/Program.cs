using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareServiceImplementList;
using System;
using System.Collections.Generic;
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
            currentContainer.RegisterType<ICustomerService, CustomerServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMaterialService, MaterialServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWorkService, WorkServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IStockService, StockServiceList>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
