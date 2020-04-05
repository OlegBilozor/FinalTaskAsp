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
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _personService.Get(id);
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personService.Get();
        }

        [HttpPost]
        public async Task<Person> Add([FromBody] Person person)
        {
            return await _personService.Add(person);
        }

        [HttpPut]
        public async Task<Person> Update([FromBody] Person person)
        {
            return await _personService.Update(person);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _personService.Delete(id);
        }
    }
}