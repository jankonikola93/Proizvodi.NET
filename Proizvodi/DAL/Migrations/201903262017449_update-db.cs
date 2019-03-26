namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proizvod", "Cena", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proizvod", "Cena", c => c.Single(nullable: false));
        }
    }
}
