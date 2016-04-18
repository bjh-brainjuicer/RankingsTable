namespace RankingsTable.EF
{
    using Microsoft.Data.Entity;

    using RankingsTable.EF.Entities;

    public interface IRankingsTableDbContext
    {
        DbSet<Player> Players { get; } 
    }
}
