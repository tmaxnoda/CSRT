using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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

        public DbSet<MottorModel> MottoModels { get; set; }
       
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Mottor> Mottors { get; set; }
        public virtual  DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Milage> Milages { get; set; }
        public virtual DbSet<MottoDriver> MottoDrivers { get; set; }
        public virtual DbSet<VehicleMovement> VehicleMovements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //var vehicleModel = modelBuilder.Entity<VehicleMovement>();
            //vehicleModel.HasKey(x => x.Id);
            var model = modelBuilder.Entity<VehicleMovement>();
            model
                .HasRequired(x => x.Moto)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
            
        }

        public System.Data.Entity.DbSet<CSRT.Areas.Security.ViewModels.MottorModelViewModel> MottorModelViewModels { get; set; }

        //public System.Data.Entity.DbSet<CSRT.AccountViewModels.RoleViewModel> RoleViewModels { get; set; }

        //public System.Data.Entity.DbSet<CSRT.Areas.Security.ViewModels.DriverViewModel> DriverViewModels { get; set; }
    }
}