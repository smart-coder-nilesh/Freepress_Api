using Freepress_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Freepress_Api.DbContextFiles
{
    public class FreepressDbContext : DbContext
    {
        public FreepressDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Author> AuthorDbContext { get; set; }
        public DbSet<newsmodel> newsDbContext { get; set; }


    }
}
