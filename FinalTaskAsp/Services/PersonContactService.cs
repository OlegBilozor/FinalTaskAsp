using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTaskAsp.Abstract;
using FinalTaskAsp.Entities;
using Microsoft.EntityFrameworkCore;


namespace FinalTaskAsp.Services
{
    public class PersonContactService : IPersonContactService
    {
        private readonly TestDbContext _db;

        public PersonContactService(TestDbContext db)
        {
            _db = db;
        }
        public async Task<PersonContact> Get(int id)
        {
            return await _db.PersonContact.FirstOrDefaultAsync(x => x.PersonId == id);
        }

        public IEnumerable<PersonContact> Get()
        {
            return _db.PersonContact.AsEnumerable()?.ToList();
        }

        public async Task<PersonContact> Add(PersonContact personContact)
        {
            var res = await _db.PersonContact.AddAsync(personContact);

            await _db.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<PersonContact> Update(PersonContact personContact)
        {
            var res = _db.PersonContact.Update(personContact);

            await _db.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await _db.PersonContact.FirstOrDefaultAsync(x => x.PersonContactId == id);

            _db.Remove(model);

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
