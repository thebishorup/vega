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
            builder.Entity<Make>().ToTable("Makes");
            builder.Entity<Modle>().ToTable("Modles");
            builder.Entity<Feature>().ToTable("Features");

            //Configure One-Many Relationship between VehicleMake & VehicleModel
            builder.Entity<Modle>()
                .HasOne(make => make.Make)
                .WithMany(model => model.Models)
                .HasForeignKey(fk => fk.MakeId);

            //Property Constrains
            builder.Entity<Modle>()
                .Property(modle => modle.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Entity<Make>()
                .Property(make => make.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}