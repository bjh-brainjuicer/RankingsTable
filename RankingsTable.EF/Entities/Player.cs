using System.ComponentModel.DataAnnotations;

namespace RankingsTable.EF.Entities
{
    using System;
    using System.Collections.Generic;

    public class Player
    {
        public Player()
        {
            this.HomeFixtures = new HashSet<Fixture>();
            this.AwayFixtures = new HashSet<Fixture>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }

        public virtual HashSet<Fixture> HomeFixtures { get; set; } 

        public virtual HashSet<Fixture> AwayFixtures { get; set; } 
    }
}
