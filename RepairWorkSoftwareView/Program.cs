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
            ApiClient.Connect();
            MailClient.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
