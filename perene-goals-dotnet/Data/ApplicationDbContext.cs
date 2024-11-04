using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using perene_goals_dotnet.Models;

namespace perene_goals_dotnet.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<perene_goals_dotnet.Models.Learning> Learning { get; set; } = null!;
    public DbSet<perene_goals_dotnet.Models.GoalsList> GoalsLists {get; set;} = null!;
    public DbSet<perene_goals_dotnet.Models.Goal> Goals {get; set;} = null!;
    public DbSet<perene_goals_dotnet.Models.GoalsStep> GoalsSteps {get; set;} = null!;
    public DbSet<perene_goals_dotnet.Models.GoalsListVote> GoalsListVotes {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GoalsList>()
                .HasMany(gl => gl.Goals)
                .WithOne(g => g.GoalsList)
                .HasForeignKey(g => g.GoalsListId);

        modelBuilder.Entity<Goal>()
                .HasMany(g => g.GoalSteps)
                .WithOne(gs => gs.Goal)
                .HasForeignKey(gs => gs.GoalId);

        modelBuilder.Entity<GoalsList>()
                .HasMany(gl => gl.GoalsListVotes)
                .WithOne(v => v.GoalsList)
                .HasForeignKey(v => v.GoalsListId);

        modelBuilder.Entity<GoalsListVote>()
                .HasIndex(v => new {v.UserId, v.GoalsListId})
                .IsUnique();
    }
}
