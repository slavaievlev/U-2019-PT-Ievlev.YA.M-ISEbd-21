
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ServiceImplementsDatabase.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ServiceImplementsDatabase.AbstractDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}