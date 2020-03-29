using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Contexts;
using StarWars.Interfaces;
using StarWars.Models;

namespace StarWars.Services
{
    public class PeopleService:IPeopleService
    {
        protected readonly AppDbContext _context;
        public PeopleService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetAsync()
        {
            return await _context.People.ToListAsync();
        }
        public async Task<int> InsertAsync(Person p)
        {
            var existinginative = _context.People.Where(x => x.Id.Equals(p.Id)).FirstOrDefault();
            if (existinginative != null)
            {
                return 0;
            }
            _context.People.Add(p);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var existingFav = _context.People.Where(x => x.Id == Id).FirstOrDefault();
            _context.People.Remove(existingFav);

            return await _context.SaveChangesAsync();


        }
    }
}
