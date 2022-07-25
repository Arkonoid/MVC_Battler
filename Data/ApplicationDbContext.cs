using Microsoft.EntityFrameworkCore;
using MVC_Battler.Models;

namespace MVC_Battler.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Character> Characters { get; set; }
}