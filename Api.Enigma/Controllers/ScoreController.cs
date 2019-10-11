using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Enigma.JsonModels;
using Api.Enigma.Repositories.Interfaces;
using Api.Enigma.Repositories.Entities;

namespace Api.Enigma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;
        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [Route("Submit")]
        [HttpPost]
        public IActionResult SubmitScore([FromBody]Score score)
        {
            try
            {
                // The score should be submit by levelม it should unique by player and level
                if (_scoreRepository.IsScoreAlreadySubmitted(score.Player, score.Level))
                {
                    _scoreRepository.UpdateScore(score.Player, score.Level, score.Time, score.Step);
                }
                else
                {
                    _scoreRepository.AddNewScore(score.Player, score.Level, score.Time, score.Step);
                }
                return Ok(score);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Route("Rank")]
        [HttpGet]
        public IActionResult GetRank()
        {
            try
            {
                List<Rank> ranking = new List<Rank>();
                List<ScoreEntity> scores = _scoreRepository.GetAllScore();
                foreach (var score in scores.GroupBy(c => c.Player))
                {
                    ranking.Add(new Rank()
                    {
                        Player = score.Key,
                        Score = score.Sum(q => q.Score)
                    });
                }

                return Ok(ranking.OrderByDescending(q => q.Score));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }

   
}