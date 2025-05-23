using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

public class MovieAppContext : DbContext
{
    public MovieAppContext(DbContextOptions<MovieAppContext> options)
        : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<CustomerMovie> CustomerMovies { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Like> Likes { get; set; }
}
