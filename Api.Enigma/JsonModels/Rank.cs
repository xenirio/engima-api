using System;
namespace Api.Enigma.JsonModels
{
    public class Rank
    {
        public string Player { get; set; }

        private decimal _score;
        public decimal Score { 
            get { return decimal.Round(_score, 2); }
            set { _score = value; } 
        }
    }
}
