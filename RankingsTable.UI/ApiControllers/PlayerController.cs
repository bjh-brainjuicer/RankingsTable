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
        
        [HttpPost]
        public void Post([FromBody]string name)
        {
            this.dbContext.Players.Add(new Player { Id = Guid.NewGuid(), Name = name });
            this.dbContext.SaveChanges();
        }
    }
}
