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
    using RankingsTable.UI.Mapping;
    using RankingsTable.UI.Models;

    [Route("api/[controller]")]
    internal class SeasonController : ApiController
    {
        private readonly IRankingsTableDbContext dbContext;

        private readonly IDTOMapper dtoMapper;

        public SeasonController(IRankingsTableDbContext dbContext, IDTOMapper dtoMapper)
        {
            this.dbContext = dbContext;
            this.dtoMapper = dtoMapper;
        }

        [HttpGet("{id}")]
        public DetailedSeasonDTO Get(Guid id)
        {
            var season = this.dbContext.Seasons.Include(s => s.Fixtures).Include(s => s.SeasonPlayers).Single(s => s.Id == id);
            return this.dtoMapper.Map<Season, DetailedSeasonDTO>(season);
        }

        [HttpGet]
        public IEnumerable<BasicSeasonDTO> Get()
        {
            return this.dtoMapper.Map<IEnumerable<Season>, IEnumerable<BasicSeasonDTO>>(this.dbContext.Seasons);
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
            var season = this.dbContext.Seasons.Include(s => s.SeasonPlayers).Single(s => s.Id == addPlayerDto.SeasonId);
            if (!season.SeasonPlayers.Any(sp => sp.PlayerId == addPlayerDto.PlayerId))
            {
                var player = this.dbContext.Players.Single(p => p.Id == addPlayerDto.PlayerId);
                season.SeasonPlayers.Add(new SeasonPlayer { Season = season, Player = player });
                this.dbContext.SaveChanges();
            }
        }
    }
}
