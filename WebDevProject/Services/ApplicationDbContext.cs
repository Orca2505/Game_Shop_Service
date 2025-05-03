using Microsoft.EntityFrameworkCore;
using WebDevProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebDevProject.Services;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Game> games => Set<Game>();
    public DbSet<User> users => Set<User>();
    public DbSet<Genre> Genre => Set<Genre>();
    public DbSet<UserGame> userGames => Set<UserGame>();
    public DbSet<GameGenre> gameGenre => Set<GameGenre>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<GameGenre>().HasKey(gameGenre => new {gameGenre.GameId, gameGenre.GenreId}); // Tells EF Core that the primary key is the two columns combined

        // This will populate the genre table with predefined genres
        builder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "RPG" },
            new Genre { Id = 2, Name = "Competitive" },
            new Genre { Id = 3, Name = "Platformer"}
        );
    }

public DbSet<WebDevProject.Models.Group> Group { get; set; } = default!;
}