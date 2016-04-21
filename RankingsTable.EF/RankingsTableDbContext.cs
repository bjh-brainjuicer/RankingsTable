namespace RankingsTable.EF
{
    using Microsoft.Data.Entity;
    using Microsoft.Data.Entity.Infrastructure;

    using RankingsTable.EF.Entities;

    public class RankingsTableDbContext : DbContext, IRankingsTableDbContext
    {
        public RankingsTableDbContext(DbContextOptions<RankingsTableDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Player> Players { get; set; }

        public DbSet<Season> Seasons { get; set; }
    }
}
