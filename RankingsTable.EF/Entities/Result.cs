using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingsTable.EF.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Result
    {
        [Key]
        public Guid Id { get; set; }

        public virtual Fixture Fixture { get; set; }

        [Required]
        public Guid FixtureId { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }
    }
}
