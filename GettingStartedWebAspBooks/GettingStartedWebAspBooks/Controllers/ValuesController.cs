using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using  GettingStartedWebAspBooks.Extensions.Calculations;


namespace GettingStartedWebAspBooks.Controllers
{
   // [Produces("application/json")]
    [Route("api/Values"),AllowAnonymous]
    public class ValuesController : Controller
    {
        private readonly ICounterService<int> _counterService;

        public ValuesController(ICounterService<int> counterService)
        {
            _counterService = counterService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new [] {"blabla 1", "blabla2"});
        }

        [HttpGet ("{id:min(5)}")]
        public IActionResult Get(int id)
        {
            return Ok($"value{id}");
        }

        [HttpGet("increment")]
        public IActionResult GetIncrement()
        {
            _counterService.Increment();

            return Ok(_counterService.GetValue());
        }

    }
}