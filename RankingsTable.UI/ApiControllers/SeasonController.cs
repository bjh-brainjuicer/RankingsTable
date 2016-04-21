namespace RankingsTable.UI.ApiControllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Mvc;
    using Microsoft.Data.Entity;

    using RankingsTable.EF;
    using RankingsTable.EF.Entities;

    [Route("api/[controller]")]
    public class SeasonController : ApiController
    {
        private readonly IRankingsTableDbContext dbContext;

        public SeasonController(IRankingsTableDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public Season Get(Guid id)
        {
            return this.dbContext.Seasons.Single(s => s.Id == id);
        }

        [HttpGet]
        public IEnumerable<Season> Get()
        {
            return this.dbContext.Seasons;
        }

        [HttpPost]
        public void Post()
        {
            this.dbContext.Seasons.Add(new Season { Id = Guid.NewGuid(), Number = this.dbContext.Seasons.Max(s => s.Number) + 1 });
            this.dbContext.SaveChanges();
        }

        [HttpPost("players")]
        public void Post([FromBody]AddPlayerDTO addPlayerDto) // TODO this isn't resolving yet
        {
            var season = this.dbContext.Seasons.Single(s => s.Id.ToString() == addPlayerDto.SeasonId);
            if (!season.SeasonPlayers.Any(sp => sp.PlayerId.ToString() == addPlayerDto.PlayerId))
            {
                var player = this.dbContext.Players.Single(p => p.Id.ToString() == addPlayerDto.PlayerId);
                season.SeasonPlayers.Add(new SeasonPlayer { Season = season, Player = player });
                this.dbContext.SaveChanges();
            }
        }

        public struct AddPlayerDTO
        {
             public string SeasonId { get; set; }

             public string PlayerId { get; set; }
        }
    }
}
