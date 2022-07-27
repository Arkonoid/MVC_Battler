using Microsoft.EntityFrameworkCore;
using MVC_Battler.Models;

namespace MVC_Battler.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Character> Characters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().HasData(new Character() {Id = 1, Name = "Jerry", HP = 50, Strength = 50});
        modelBuilder.Entity<Character>().HasData(new Character() {Id = 2, Name = "Larry", HP = 25, Strength = 75});
        modelBuilder.Entity<Character>().HasData(new Character() {Id = 3, Name = "Gary", HP = 75, Strength = 25});
    }
}