namespace TrashcollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PickUpCharge", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "CustomerAddress", c => c.String());
            AddColumn("dbo.Employees", "Customer_CustomerId", c => c.Int());
            AlterColumn("dbo.Customers", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employees", "LastName", c => c.String(maxLength: 50));
            CreateIndex("dbo.Employees", "Customer_CustomerId");
            AddForeignKey("dbo.Employees", "Customer_CustomerId", "dbo.Customers", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Employees", new[] { "Customer_CustomerId" });
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            DropColumn("dbo.Employees", "Customer_CustomerId");
            DropColumn("dbo.Employees", "CustomerAddress");
            DropColumn("dbo.Employees", "PickUpCharge");
        }
    }
}
