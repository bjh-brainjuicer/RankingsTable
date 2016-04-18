using System.ComponentModel.DataAnnotations;

namespace RankingsTable.EF.Entities
{
    using System;

    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }
    }
}
