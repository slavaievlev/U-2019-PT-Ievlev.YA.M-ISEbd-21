using RepairWorkSoftwareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareServiceImplementList
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Customer> Customers { get; set; }

        public List<Material> Materials { get; set; }

        public List<Order> Orders { get; set; }

        public List<Work> Works { get; set; }

        public List<MaterialWork> WorkMaterials { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Materials = new List<Material>();
            Orders = new List<Order>();
            Works = new List<Work>();
            WorkMaterials = new List<MaterialWork>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }

            return instance;
        }
    }
}
