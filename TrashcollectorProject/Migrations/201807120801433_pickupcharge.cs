namespace TrashcollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pickupcharge : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "PickUpCharge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "PickUpCharge", c => c.Int(nullable: false));
        }
    }
}
