using Microsoft.EntityFrameworkCore;
using NetCore.Data.Model;
using System.Threading.Tasks;

namespace NetCore.Data.Context
{
    public class NetCoreContext : DbContext
    {
        public NetCoreContext() { }
        public NetCoreContext(DbContextOptions<NetCoreContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=mssql02.au.ds.network;Database=DBsp;User Id=dbusersmile;password=hi7T5Gyx3ts&0wNml;Trusted_Connection=False;MultipleActiveResultSets=true");
        }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

    }
}
