using System.ComponentModel.DataAnnotations;

namespace RankingsTable.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

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
        
        [InverseProperty("HomePlayer")]
        public virtual ICollection<Fixture> HomeFixtures { get; set; }

        [InverseProperty("AwayPlayer")]
        public virtual ICollection<Fixture> AwayFixtures { get; set; } 
    }
}
