using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

public class MovieAppContext : DbContext
{
    public MovieAppContext(DbContextOptions<MovieAppContext> options)
        : base(options) { }

    public DbSet<Movie> Movies { get; set; }
}
