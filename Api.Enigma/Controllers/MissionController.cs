using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Enigma.JsonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionLib;

namespace Api.Enigma.Controllers
{
    [Route("api/mission")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private IMissionGenerator generator;

        public MissionController(IMissionGenerator missionGenerator)
        {
            generator = missionGenerator;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult("123");
        }

        [Route("{level}")]
        [HttpGet]
        public IActionResult GetMission(int level)
        {
            if (level <= 0)
                return new BadRequestResult();

            // Simple Level Design... At All :D
            var levels = new List<Level>();

            for (int sublevel = 0; sublevel < 5; sublevel++)
            {
                var difficulty = ((level - 1) * 5 + sublevel) + 1;

                var numTick = level + 1;
                var numRotor = sublevel + 1;
                var numMove = Math.Max(4, difficulty / 3);
                var numRelation = Math.Max(numRotor - 1, Convert.ToInt32(Math.Floor(numRotor * (numRotor - 1) * Math.Min(1.0, (double)difficulty / 25) * 0.6)));

                var mission = generator.Generate(numTick, numRotor, numRelation, numMove);
                levels.Add(convertToJsonModel(mission, level, sublevel + 1));
            }
            
            return new JsonResult(levels);
        }

        private Level convertToJsonModel(MissionInfo mission, int level, int sublevel)
        {
            var rotors = mission.Rotors.Select(e => new RotorJsonModel()
            {
                Id = e.Id,
                Ticks = mission.NumberOfTick,
                State = e.CurrentState
            }).ToList();

            var circuits = mission.Rotors.Select(e => new Circuit()
            {
                Switch = e.Id,
                Rotors = e.AffectTo.Select(f => mission.Rotors[f].Id).ToArray()
            }).ToList();

            return new Level()
            {
                Major = level,
                Minor = sublevel,
                Rotors = rotors,
                Circuits = circuits,
                Layout = mission.Layout,
                Answer = mission.Answer.Count
            };
        }
    }
}