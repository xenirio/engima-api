using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Enigma.JsonModels;

namespace Api.Enigma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        [Route("Submit")]
        [HttpPost]
        public IActionResult SubmitScore([FromBody]Score score)
        {
            return Ok(score);
        }

        [Route("Rank")]
        [HttpGet]
        public IActionResult GetRank()
        {
            return Ok(new Rank());
        }
    }

   
}