using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using perene_goals_dotnet.Models;

namespace perene_goals_dotnet.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<perene_goals_dotnet.Models.Learning> Learning { get; set; } = null!;
}
