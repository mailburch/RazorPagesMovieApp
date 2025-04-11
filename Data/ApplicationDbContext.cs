using Microsoft.EntityFrameworkCore;
using RazorPagesMovieApp.Models;

namespace RazorPagesMovieApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
