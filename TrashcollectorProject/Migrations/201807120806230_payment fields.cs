namespace TrashcollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PaymentComplete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PaymentComplete");
        }
    }
}
