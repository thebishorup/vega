using Microsoft.EntityFrameworkCore;
using Vega.DTO;

namespace Vega.Data
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {

        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Customizing the EF Model
            builder.Entity<VehicleMake>().ToTable("VehicleMake");
            builder.Entity<VehicleModel>().ToTable("VehicleModel");
            builder.Entity<VehicleFeature>().ToTable("VehicleFeature");

            //Configure One-Many Relationship between VehicleMake & VehicleModel
            builder.Entity<VehicleModel>()
                .HasOne(make => make.VehicleMake)
                .WithMany(model => model.VehicleModels)
                .HasForeignKey(fk => fk.VehicleMakeId);
        }
    }
}