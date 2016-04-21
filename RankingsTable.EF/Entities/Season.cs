using System;

namespace RankingsTable.EF.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Season
    {
        public Season()
        {
            this.Fixtures = new HashSet<Fixture>();
            this.SeasonPlayers = new HashSet<SeasonPlayer>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Number { get; set; }

        public virtual ICollection<Fixture> Fixtures { get; set; } 

        public virtual ICollection<SeasonPlayer> SeasonPlayers { get; set; } 
    }
}
