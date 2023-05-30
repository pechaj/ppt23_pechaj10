using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;

namespace Ppt23.API.Data
{
    public class PptDbContext : DbContext
    {
        public PptDbContext(DbContextOptions<PptDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Vybaveni> Vybavenis => Set<Vybaveni>();
        
        public DbSet<Revize> Revizes => Set<Revize>();

        public DbSet<Ukon> Ukons => Set<Ukon>();

        public DbSet<Pracovnik> Pracovniks => Set<Pracovnik>();

    }

}
