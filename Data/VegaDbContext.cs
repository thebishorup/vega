using Microsoft.EntityFrameworkCore;
using vega.Model;
using Vega.Model;

namespace Vega.Data
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {

        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Modle> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Customizing the EF Model
            builder.Entity<Make>().ToTable("Makes");
            builder.Entity<Modle>().ToTable("Modles");
            builder.Entity<Feature>().ToTable("Features");
            builder.Entity<Vehicle>().ToTable("Vehicle");
            builder.Entity<VehicleFeature>().ToTable("VehicleFeature");

            #region EF Relatiosnhips Configurations
            //Configure One-Many Relationship between Make & Model
            builder.Entity<Modle>()
                .HasOne(make => make.Make)
                .WithMany(model => model.Models)
                .HasForeignKey(fk => fk.MakeId);

            //Configure Many-Many relationship between Vehicle and Feature
            builder.Entity<VehicleFeature>()
                .HasKey(v => new { v.VehicleId, v.FeatureId });

            builder.Entity<VehicleFeature>()
                .HasOne(v => v.Vehicle)
                .WithMany(v => v.VehicleFeatures)
                .HasForeignKey(v => v.VehicleId);

            builder.Entity<VehicleFeature>()
                .HasOne(f => f.Feature)
                .WithMany(f => f.VehicleFeatures)
                .HasForeignKey(f => f.FeatureId);
            #endregion

            #region EF property configurations
            //Property Constrains
            //Model
            builder.Entity<Modle>()
                .Property(modle => modle.Name)
                .IsRequired()
                .HasMaxLength(255);

            //Make
            builder.Entity<Make>()
                .Property(make => make.Name)
                .IsRequired()
                .HasMaxLength(255);

            //Vehicle
            builder.Entity<Vehicle>()
                .Property(vehicle => vehicle.Make)
                .IsRequired();

            builder.Entity<Vehicle>()
                .Property(v => v.ContactName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Entity<Vehicle>()
                .Property(v => v.ContactPhone)
                .IsRequired()
                .HasMaxLength(255);

            builder.Entity<Vehicle>()
                .Property(v => v.CreatedBy)
                .HasMaxLength(255);

            builder.Entity<Vehicle>()
                .Property(v => v.Updatedby)
                .HasMaxLength(255);

            #endregion
        }
    }
}