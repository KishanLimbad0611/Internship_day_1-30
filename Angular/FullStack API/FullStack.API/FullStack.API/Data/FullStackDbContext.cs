using FullStack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Data
{
    public class FullStackDbContext : DbContext
    {
        //-----------created the constructor 
        public FullStackDbContext(DbContextOptions options) : base(options) { 
        }
        public DbSet<User> Users { get; set; }
    }
}
