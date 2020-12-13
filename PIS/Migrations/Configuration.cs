using System.Data.Entity.Migrations;

namespace PIS.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DbContext context)
        {
        }
    }
}