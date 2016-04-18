namespace RankingsTable.Data
{
    using Microsoft.Data.Entity;

    using RankingsTable.Data.Entities;

    interface IRankingsTableDbContext
    {
        DbSet<Player> Players { get; } 
    }
}
