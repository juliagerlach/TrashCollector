namespace TrashcollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extraday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ExtraDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ExtraDay");
        }
    }
}
