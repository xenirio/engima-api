using System;
namespace Api.Enigma.JsonModels
{
    public class Score
    {
        public string Player { get; set; }

        public int Level { get; set; }

        public int Time { get; set; }

        public int Step { get; set; }
    }
}
