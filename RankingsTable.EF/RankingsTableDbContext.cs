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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasMany(p => p.HomeFixtures).WithOne(f => f.HomePlayer).HasForeignKey(f => f.HomePlayerId).IsRequired();
            modelBuilder.Entity<Player>().HasMany(p => p.AwayFixtures).WithOne(f => f.AwayPlayer).HasForeignKey(f => f.AwayPlayerId).IsRequired();

            /*
            modelBuilder.Entity<Season>().HasMany(s => s.Fixtures).WithOne(f => f.Season).HasForeignKey(f => f.SeasonId);

            modelBuilder.Entity<Fixture>().HasOne(f => f.Result).WithOne(r => r.Fixture).HasForeignKey((Result r) => r.FixtureId);
            */
        }
    }
}
