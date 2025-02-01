using Microsoft.EntityFrameworkCore;
using MovieInfo.Repositories.Models;

namespace MovieInfo.Repositories
{
    public class DataContext : DbContext    
    {
        public DataContext() { }

        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
