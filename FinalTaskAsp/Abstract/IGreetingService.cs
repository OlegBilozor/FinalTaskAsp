using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTaskAsp.Entities;

namespace FinalTaskAsp.Abstract
{
    public interface IGreetingService
    {
        Task<Greeting> Get(int id);
        IEnumerable<Greeting> Get();
        Task<Greeting> Add(Greeting greeting);
        Task<Greeting> Update(Greeting greeting);
        Task<bool> Delete(int id);
    }
}
