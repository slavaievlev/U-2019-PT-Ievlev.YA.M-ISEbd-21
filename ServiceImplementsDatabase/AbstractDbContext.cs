using RepairWorkSoftwareModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementsDatabase
{
    public class AbstractDbContext : DbContext
    {
        public AbstractDbContext() : base("AbstractDatabase")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            var cs = ConfigurationManager.ConnectionStrings["AbstractDbContext"];
            var sCs = cs.ConnectionString;
            this.Database.Connection.ConnectionString = sCs;
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Material> Materials { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Work> Works { get; set; }

        public virtual DbSet<MaterialWork> WorkMaterials { get; set; }

        public virtual DbSet<Stock> Stocks { get; set; }

        public virtual DbSet<StockMaterial> StockMaterials { get; set; }
    }
}
