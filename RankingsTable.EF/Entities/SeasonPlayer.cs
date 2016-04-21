using System.ComponentModel.DataAnnotations;

namespace RankingsTable.EF.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SeasonPlayer
    {
        public SeasonPlayer()
        {
            this.HomeFixtures = new HashSet<Fixture>();
            this.AwayFixtures = new HashSet<Fixture>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SeasonId { get; set; }

        [Required]
        public Guid PlayerId { get; set; }

        public virtual Season Season { get; set; }

        public virtual Player Player { get; set; }
        
        [InverseProperty("HomePlayer")]
        public virtual ICollection<Fixture> HomeFixtures { get; set; }

        [InverseProperty("AwayPlayer")]
        public virtual ICollection<Fixture> AwayFixtures { get; set; }
    }
}
