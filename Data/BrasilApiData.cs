using Microsoft.EntityFrameworkCore;
using BrasilApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ClimaAeroporto> ClimaAeroporto { get; set; }
    public DbSet<ClimaCidade> ClimaCidade { get; set; }
    public DbSet<Logs> Logs { get; set; }
}
