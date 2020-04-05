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
    public class PersonContactController : ControllerBase
    {
        private readonly IPersonContactService _personContactService;

        public PersonContactController(IPersonContactService personContactService)
        {
            _personContactService = personContactService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PersonContact> Get(int id)
        {
            return await _personContactService.Get(id);
        }

        [HttpGet]
        public IEnumerable<PersonContact> Get()
        {
            return _personContactService.Get();
        }

        [HttpPost]
        public async Task<PersonContact> Add([FromBody] PersonContact personContact)
        {
            return await _personContactService.Add(personContact);
        }

        [HttpPut]
        public async Task<PersonContact> Update([FromBody] PersonContact personContact)
        {
            return await _personContactService.Update(personContact);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _personContactService.Delete(id);
        }
    }
}