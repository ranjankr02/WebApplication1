using Microsoft.EntityFrameworkCore;
using WebApplication1.App.DAL.EntityModel;

namespace WebApplication1.App.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
