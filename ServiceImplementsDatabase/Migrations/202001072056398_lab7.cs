namespace ServiceImplementsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lab7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFIO = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        WorkId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                        ImplementerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Implementers", t => t.ImplementerId)
                .ForeignKey("dbo.Works", t => t.WorkId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.WorkId)
                .Index(t => t.ImplementerId);
            
            CreateTable(
                "dbo.Implementers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterialWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialId = c.Int(nullable: false),
                        WorkId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Works", t => t.WorkId, cascadeDelete: true)
                .Index(t => t.MaterialId)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Stocks", t => t.StockId, cascadeDelete: true)
                .Index(t => t.StockId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterialWorks", "WorkId", "dbo.Works");
            DropForeignKey("dbo.MaterialWorks", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.StockMaterials", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.StockMaterials", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Orders", "WorkId", "dbo.Works");
            DropForeignKey("dbo.Orders", "ImplementerId", "dbo.Implementers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MessageInfos", "CustomerId", "dbo.Customers");
            DropIndex("dbo.StockMaterials", new[] { "MaterialId" });
            DropIndex("dbo.StockMaterials", new[] { "StockId" });
            DropIndex("dbo.MaterialWorks", new[] { "WorkId" });
            DropIndex("dbo.MaterialWorks", new[] { "MaterialId" });
            DropIndex("dbo.Orders", new[] { "ImplementerId" });
            DropIndex("dbo.Orders", new[] { "WorkId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.MessageInfos", new[] { "CustomerId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.StockMaterials");
            DropTable("dbo.Materials");
            DropTable("dbo.MaterialWorks");
            DropTable("dbo.Works");
            DropTable("dbo.Implementers");
            DropTable("dbo.Orders");
            DropTable("dbo.MessageInfos");
            DropTable("dbo.Customers");
        }
    }
}
