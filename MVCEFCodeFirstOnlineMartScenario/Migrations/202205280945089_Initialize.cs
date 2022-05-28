namespace MVCEFCodeFirstOnlineMartScenario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        PurchaseQTY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ProductQTY = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        ProductImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false) //make it false
                .Index(t => t.UserId)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserTypeID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Dob = c.DateTime(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        QuId = c.Int(nullable: false),
                        Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.SecurityQuestions", t => t.QuId, cascadeDelete: true)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeID, cascadeDelete: true)
                .Index(t => t.UserTypeID)
                .Index(t => t.QuId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        HouseNo = c.String(nullable: false),
                        Area = c.String(nullable: false),
                        Landmark = c.String(),
                        City = c.String(nullable: false),
                        PinCode = c.Int(nullable: false),
                        State = c.String(nullable: false),
                        DefaultAddress = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SecurityQuestions",
                c => new
                    {
                        QuId = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.QuId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeID = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Carts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserTypeID", "dbo.UserTypes");
            DropForeignKey("dbo.Users", "QuId", "dbo.SecurityQuestions");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "QuId" });
            DropIndex("dbo.Users", new[] { "UserTypeID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.Carts", new[] { "ProductID" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.SecurityQuestions");
            DropTable("dbo.Contacts");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}
