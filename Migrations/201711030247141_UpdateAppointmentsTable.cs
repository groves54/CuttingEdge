namespace CuttingEdge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppointmentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Phone");
        }
    }
}
