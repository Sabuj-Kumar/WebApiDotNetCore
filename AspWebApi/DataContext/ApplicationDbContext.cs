using AspWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspWebApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PostModel> Post{get; set; }
    }
}
