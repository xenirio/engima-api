using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Enigma.JsonModels
{
    public class Level
    {
        [JsonProperty("major")]
        public int Major { get; set; }

        [JsonProperty("minor")]
        public int Minor { get; set; }
        
        [JsonProperty("answer")]
        public int Answer { get; set; }

        [JsonProperty("rotors")]
        public List<RotorJsonModel> Rotors { get; set; }

        [JsonProperty("circuits")]
        public List<Circuit> Circuits { get; set; }

        [JsonProperty("layout")]
        public string[][] Layout { get; set; }
    }

    public class RotorJsonModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ticks")]
        public int Ticks { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }
    }

    public class Circuit
    {
        [JsonProperty("switch")]
        public string Switch { get; set; }

        [JsonProperty("rotors")]
        public string[] Rotors { get; set; }
    }
}
