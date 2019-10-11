using System;
namespace Api.Enigma.Repositories.Entities
{
    public partial class ScoreEntity
    {
        public int Score
        {
            get
            {
                // score = (step / time) * 10
                return (this.Step / this.Time) * this.Level * 10;
            }

        }
    }
}
