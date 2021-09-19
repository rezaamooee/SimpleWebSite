using Entity.DBEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Contexts
{
    public interface ISiteDbContext
    {

        public DbSet<EntRole> Roles { set; get; }
        public DbSet<EntUser> Users { set; get; }
        public DbSet<EntLogin> Logins { set; get; }
        public DbSet<EntTopic> Topics { set; get; }
        public DbSet<EntPost> Posts { set; get; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
