using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AssetType> AssetTypes { get; set; }
    }
}