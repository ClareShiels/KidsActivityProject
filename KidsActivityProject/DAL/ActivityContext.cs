using KidsActivityProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace KidsActivityProject.DAL
{
    public class ActivityContext : DbContext
    {
        public ActivityContext() : base("ActivityContext")
        {
        }

        public DbSet<Kid> Kids { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}