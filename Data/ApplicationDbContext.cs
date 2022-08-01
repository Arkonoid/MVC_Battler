using Microsoft.EntityFrameworkCore;
using MVC_Battler.Models;

namespace MVC_Battler.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Enemy> Enemies { get; set; }
    public DbSet<Character> Combatants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasData(new Player() {Id = 1, Name = "Jerry", HP = 100, Strength = 20, Toughness = 10});
        modelBuilder.Entity<Player>().HasData(new Player() {Id = 2, Name = "Larry", HP = 80, Strength = 40, Toughness = 5});
        modelBuilder.Entity<Player>().HasData(new Player() {Id = 3, Name = "Gary", HP = 120, Strength = 15, Toughness = 12});
    }
}