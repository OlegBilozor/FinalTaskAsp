using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTaskAsp.Abstract;
using FinalTaskAsp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalTaskAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        private readonly IGreetingService _greetingService;

        public GreetingController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Greeting> Get(int id)
        {
            return await _greetingService.Get(id);
        }

        [HttpGet]
        public IEnumerable<Greeting> Get()
        {
            return _greetingService.Get();
        }

        [HttpPost]
        public async Task<Greeting> Add([FromBody] Greeting greeting)
        {
            return await _greetingService.Add(greeting);
        }

        [HttpPut]
        public async Task<Greeting> Update([FromBody] Greeting greeting)
        {
            return await _greetingService.Update(greeting);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _greetingService.Delete(id);
        }
    }
}