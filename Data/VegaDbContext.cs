using Microsoft.EntityFrameworkCore;

public class VegaDbContext : DbContext
{
    public VegaDbContext(DbContextOptions<VegaDbContext> options) : base (options)
    {
        
    }
}