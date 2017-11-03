namespace CuttingEdge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Time", c => c.DateTime(nullable: false));
        }
    }
}
