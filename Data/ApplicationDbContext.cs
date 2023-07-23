using Microsoft.EntityFrameworkCore;
using Movies__CRUD_Operations_.Models;

namespace Movies__CRUD_Operations_.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<Genre> Genres{ get; set; }
        public DbSet<Movie> Movies{ get; set; }
    }
}
