namespace PIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_user_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role_id", c => c.Int(nullable: true));
            AddColumn("dbo.Users", "Locality_id", c => c.Int(nullable: true));
            CreateIndex("dbo.Users", "Role_id");
            CreateIndex("dbo.Users", "Locality_id");
            AddForeignKey("dbo.Users", "Locality_id", "dbo.Localities", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "Role_id", "dbo.Roles", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_id", "dbo.Roles");
            DropForeignKey("dbo.Users", "Locality_id", "dbo.Localities");
            DropIndex("dbo.Users", new[] { "Locality_id" });
            DropIndex("dbo.Users", new[] { "Role_id" });
            DropColumn("dbo.Users", "Locality_id");
            DropColumn("dbo.Users", "Role_id");
        }
    }
}
