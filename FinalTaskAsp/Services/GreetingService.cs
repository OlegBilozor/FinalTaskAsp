using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTaskAsp.Abstract;
using FinalTaskAsp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalTaskAsp.Services
{
    public class GreetingService : IGreetingService
    {
        private readonly TestDbContext _db;

        public GreetingService(TestDbContext db)
        {
            _db = db;
        }
        public async Task<Greeting> Get(int id)
        {
            return await _db.Greeting.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Greeting> Get()
        {
            return _db.Greeting.AsEnumerable()?.ToList();
        }

        public async Task<Greeting> Add(Greeting greeting)
        {
            var res = await _db.Greeting.AddAsync(greeting);

            await _db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Greeting> Update(Greeting greeting)
        {
            var res = _db.Greeting.Update(greeting);

            await _db.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await _db.Greeting.FirstOrDefaultAsync(x => x.Id == id);

            _db.Remove(model);

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
