using LiteDBXamarinForms.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBXamarinForms.Repositories
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<Person>> ReadAll();
        Task<Person> UpdateAsync(Person person);
        Task<Person> AddAsync(Person person);
        Task<bool> DeleteAsync(Person person);
    }
}
