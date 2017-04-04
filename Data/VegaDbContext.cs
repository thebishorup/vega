using Microsoft.EntityFrameworkCore;
using Vega.Model;

namespace Vega.Data
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {

        }

        public DbSet<Make> VehicleMakes { get; set; }
        public DbSet<Modle> VehicleModels { get; set; }
        public DbSet<Feature> VehicleFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Customizing the EF Model
            builder.Entity<Make>().ToTable("VehicleMake");
            builder.Entity<Modle>().ToTable("VehicleModel");
            builder.Entity<Feature>().ToTable("VehicleFeature");

            //Configure One-Many Relationship between VehicleMake & VehicleModel
            builder.Entity<Modle>()
                .HasOne(make => make.Make)
                .WithMany(model => model.Models)
                .HasForeignKey(fk => fk.MakeId);
        }
    }
}