using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTaskAsp.Entities;

namespace FinalTaskAsp.Abstract
{
    public interface IPersonService
    {
        Task<Person> Get(int id);
        IEnumerable<Person> Get();
        Task<Person> Add(Person person);
        Task<Person> Update(Person person);
        Task<bool> Delete(int id);
    }
}
