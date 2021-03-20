using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Controllers
{
    [Route("api/")]
    public class LandingPageController : ControllerBase
    {
        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok(true);
        }
    }
}
