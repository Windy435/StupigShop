namespace StupigShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreQuantityToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quanity", c => c.Int());
            Sql("update dbo.Products set Quanity = 0");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quanity");
        }
    }
}
