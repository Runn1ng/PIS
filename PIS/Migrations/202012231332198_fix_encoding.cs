namespace PIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_encoding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "Note", c => c.String(maxLength: 4000));
            AlterColumn("dbo.PlanDistricts", "Address", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Roles", "Name", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String());
            AlterColumn("dbo.PlanDistricts", "Address", c => c.String());
            DropColumn("dbo.Plans", "Note");
        }
    }
}
