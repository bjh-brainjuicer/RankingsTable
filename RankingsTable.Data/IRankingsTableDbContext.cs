namespace RankingsTable.Data
{
    using Microsoft.Data.Entity;

    using RankingsTable.Data.Entities;

    public interface IRankingsTableDbContext
    {
        DbSet<Player> Players { get; } 
    }
}
