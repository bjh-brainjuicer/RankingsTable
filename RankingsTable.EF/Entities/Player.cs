using System.ComponentModel.DataAnnotations;

namespace RankingsTable.EF.Entities
{
    using System;
    using System.Collections.Generic;

    public class Player
    {
        public Player()
        {
            this.SeasonPlayers = new HashSet<SeasonPlayer>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }
       
        public virtual ICollection<SeasonPlayer> SeasonPlayers { get; set; } 
    }
}
