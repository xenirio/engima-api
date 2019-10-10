using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enigma.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Enigma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        [Route("Submit")]
        [HttpPost]
        public IActionResult SubmitScore([FromBody]ScoreViewModel score)
        {
            return Ok(score);
        }

        [Route("Rank")]
        [HttpGet]
        public IActionResult GetRank()
        {
            return Ok(new RankViewModel());
        }
    }

   
}