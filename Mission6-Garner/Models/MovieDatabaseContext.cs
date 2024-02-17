using Microsoft.EntityFrameworkCore;

namespace Mission6_Garner.Models
{
    public class MovieDatabaseContext : DbContext
    {
        public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options): base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
