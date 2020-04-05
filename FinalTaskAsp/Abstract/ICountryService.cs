using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTaskAsp.Entities;

namespace FinalTaskAsp.Abstract
{
    public interface ICountryService
    {
        Task<Country> Get(string code);
        IEnumerable<Country> Get();
        Task<Country> Add(Country country);
        Task<Country> Update(Country country);
        Task<bool> Delete(string code);
    }
}
