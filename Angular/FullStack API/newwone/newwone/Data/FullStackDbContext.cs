using Microsoft.EntityFrameworkCore;
using newwone.Model;

namespace newwone.Data
{
    public class FullStackDbContext :DbContext
    {
        //-----------created the constructor 
        public FullStackDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
