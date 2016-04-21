namespace RankingsTable.UI.ApiControllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Mvc;

    using RankingsTable.EF;
    using RankingsTable.EF.Entities;

    [Route("api/[controller]")]
    public class PlayerController : ApiController
    {
        private readonly IRankingsTableDbContext dbContext;

        public PlayerController(IRankingsTableDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public Player Get(Guid id)
        {
            return this.dbContext.Players.Single(s => s.Id == id);
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return this.dbContext.Players;
        }

        /* TODO
        [HttpPost]
        public void Post()
        {
            this.dbContext.Seasons.Add(new Season { Id = Guid.NewGuid(), Number = this.dbContext.Seasons.Max(s => s.Number) + 1 });
            this.dbContext.SaveChanges();
        }
        */
    }
}
