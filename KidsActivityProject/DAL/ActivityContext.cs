using MiniProjectWebService.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MiniProjectWebService.DAL
{
    public class ActivityContext : DbContext
    {
        public ActivityContext() : base("ActivityContext")
        {
        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Activity> Activitiess { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}