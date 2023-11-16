using Microsoft.EntityFrameworkCore;

namespace Movies.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options) 
        {
            
        }

        public DbSet<Genre> Generes { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}
