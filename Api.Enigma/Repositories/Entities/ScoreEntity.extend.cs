using System;
using System.Diagnostics;

namespace Api.Enigma.Repositories.Entities
{
    public partial class ScoreEntity
    {
        public decimal Score
        {
            get
            {
                // score = (step / time) * 10
                return (decimal.Divide(1.00m, Convert.ToDecimal(this.Step)) + decimal.Divide(1.00m,Convert.ToDecimal(this.Time))) * this.Level * 10;
            }

        }
    }
}
