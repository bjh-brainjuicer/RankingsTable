using System;

namespace RankingsTable.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }
    }
}
