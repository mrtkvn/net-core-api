using Microsoft.EntityFrameworkCore;
using NetCore.Data.Model;
using System.Threading.Tasks;

namespace NetCore.Data.Context
{
    public class NetCoreContext : DbContext
    {
        public NetCoreContext(DbContextOptions<NetCoreContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

    }
}
