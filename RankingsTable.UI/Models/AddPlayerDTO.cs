namespace RankingsTable.UI.Models
{
    using System;

    internal struct AddPlayerDTO
    {
        public Guid SeasonId { get; set; }

        public Guid PlayerId { get; set; }
    }
}