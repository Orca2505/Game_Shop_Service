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
            new Genre { Id = 3, Name = "Platformer"},
            new Genre { Id = 4, Name = "Action"},
            new Genre { Id = 5, Name = "Simulation"},
            new Genre { Id = 6, Name = "FPS"},
            new Genre { Id = 7, Name = "Puzzle"},
            new Genre { Id = 8, Name = "Sports"},
            new Genre { Id = 9, Name = "Fighting"},
            new Genre { Id = 10, Name = "Party"},
            new Genre { Id = 11, Name = "Adventure"},
            new Genre { Id = 12, Name = "Strategy"},
            new Genre { Id = 13, Name = "Racing"}
        );
    }

public DbSet<WebDevProject.Models.Group> Group { get; set; } = default!;
}