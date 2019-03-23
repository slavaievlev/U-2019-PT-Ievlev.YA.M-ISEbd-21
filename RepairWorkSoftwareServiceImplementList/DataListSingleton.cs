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

        public List<Stock> Stocks { get; set; }

        public List<StockMaterial> StockMaterials { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Materials = new List<Material>();
            Orders = new List<Order>();
            Works = new List<Work>();
            WorkMaterials = new List<MaterialWork>();
            Stocks = new List<Stock>();
            StockMaterials = new List<StockMaterial>();
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
