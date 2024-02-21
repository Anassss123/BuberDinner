using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BuberDinner.Api.Controllers
{
    [Route ("[controller]")]
    public class BillController : ApiController
    {
        [HttpGet]
        public IActionResult Bills() 
        {
            return Ok("the bill will be here");
        }
    }
}