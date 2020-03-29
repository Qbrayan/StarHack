using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Interfaces
{
    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetAsync();
        Task<int> InsertAsync(Person p);

        Task<int> DeleteAsync(int Id);
    }
}
