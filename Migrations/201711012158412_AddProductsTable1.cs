namespace CuttingEdge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductsTable1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Genre", c => c.Int(nullable: false));
        }
    }
}
