using Freepress_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Freepress_Api.DbContextFiles
{
    public class FreepressDbContext : DbContext
    {
        public FreepressDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Author> Author { get; set; }
        public DbSet<newsmodel> news { get; set; }
        public DbSet<Subscribe> subscribe { get; set; }


    }
}
