using System.Data.Entity;
using PIS.Models;

namespace PIS
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("name=DbModel")
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}