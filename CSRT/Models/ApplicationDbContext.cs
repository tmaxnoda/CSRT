using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CSRT.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CSRT", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Milage> Milages { get; set; }
        public DbSet<CarDriver> CarDrivers { get; set; }
        public DbSet<VehicleMovement> VehicleMovements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var vehicleModel = modelBuilder.Entity<VehicleMovement>();
            vehicleModel.HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}