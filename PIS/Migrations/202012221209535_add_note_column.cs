namespace PIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_note_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "Note");
        }
    }
}
