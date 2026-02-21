using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

// EF Core DbContext — bridges the Movie model to the SQLite database
public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {
    }

    // Represents the Movies table in the database
    public DbSet<Movie> Movies { get; set; }
}
