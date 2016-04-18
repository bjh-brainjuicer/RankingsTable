using Microsoft.Data.Entity;

namespace RankingsTable.Data
{
    using Microsoft.Data.Entity.Infrastructure;

    using RankingsTable.Data.Entities;

    public class RankingsTableDbContext : DbContext, IRankingsTableDbContext
    {
        public RankingsTableDbContext(DbContextOptions<RankingsTableDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Player> Players { get; set; }
    }
}
