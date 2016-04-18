using System;

namespace RankingsTable.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
