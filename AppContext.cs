using Microsoft.EntityFrameworkCore;
using Model;

namespace efeksamen;

public class AppContext : DbContext
{
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Studio> Studios => Set<Studio>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Cinimaxx.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>().ToTable("Actors");
        modelBuilder.Entity<Movie>().ToTable("Movies");
        modelBuilder.Entity<Studio>().ToTable("Studios");
    }
    
}