using System;

namespace RankingsTable.EF.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Fixture
    {
        [Key]
        public Guid Id { get; set; }
        
        public virtual Player HomePlayer { get; set; }

        public virtual Player AwayPlayer { get; set; }

        public virtual Season Season { get; set; }

        public virtual Result Result { get; set; }

        [Required]
        public Guid HomePlayerId { get; set; }

        [Required]
        public Guid AwayPlayerId { get; set; }

        [Required]
        public Guid SeasonId { get; set; }
    }
}
