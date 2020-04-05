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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<Country> Get(string code)
        {
            return await _countryService.Get(code);
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _countryService.Get();
        }

        [HttpPost]
        public async Task<Country> Add([FromBody] Country country)
        {
            return await _countryService.Add(country);
        }

        [HttpPut]
        public async Task<Country> Update([FromBody] Country country)
        {
            return await _countryService.Update(country);
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<bool> Delete(string code)
        {
            return await _countryService.Delete(code);
        }
    }
}