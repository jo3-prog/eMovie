using eMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
