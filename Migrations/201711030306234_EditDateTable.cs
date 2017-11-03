namespace CuttingEdge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDateTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Time");
        }
    }
}
