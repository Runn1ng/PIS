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
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Locality> Localities { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<PlanDistrict> PlanDistricts { get; set; }
    }
}