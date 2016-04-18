using Microsoft.Data.Entity;

namespace RankingsTable.Data
{
    using RankingsTable.Data.Entities;

    public class RankingsTableDbContext : DbContext, IRankingsTableDbContext
    {
        public DbSet<Player> Players { get; set; }
    }
}
