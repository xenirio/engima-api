using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Enigma.Repositories.Entities
{
    public partial class ScoreEntity
    {
        [Key]
        public int ScoreId { get; set; }

        public string Player { get; set; }

        public int Level { get; set; }

        public int Time { get; set; }

        public int Step { get; set; }
    }
}
