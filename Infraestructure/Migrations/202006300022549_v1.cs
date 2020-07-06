namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Prize = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        InvoiceID = c.Int(nullable: false),
                        Client_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.DetailID)
                .ForeignKey("dbo.Users", t => t.Client_UserID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.InvoiceID)
                .Index(t => t.Client_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        UserTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeID, cascadeDelete: true)
                .Index(t => t.UserTypeID);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeID = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
                    })
                .PrimaryKey(t => t.UserTypeID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        InvoiceNumber = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Prize = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Details", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Details", "Client_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "UserTypeID", "dbo.UserTypes");
            DropIndex("dbo.Users", new[] { "UserTypeID" });
            DropIndex("dbo.Details", new[] { "Client_UserID" });
            DropIndex("dbo.Details", new[] { "InvoiceID" });
            DropIndex("dbo.Details", new[] { "ProductID" });
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Details");
        }
    }
}
