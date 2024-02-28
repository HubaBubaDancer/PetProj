using Microsoft.EntityFrameworkCore;
using PetProject.Models;

namespace PetProject;

public class AppDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    
    
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=baseone;Username=postgres;Password=0909");
}