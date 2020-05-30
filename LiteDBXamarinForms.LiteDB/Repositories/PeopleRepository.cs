using LiteDB;
using LiteDBXamarinForms.Models;
using LiteDBXamarinForms.Repositories;
using LiteDBXamarinForms.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBXamarinForms.LiteDB.Repositories
{
    public class PeopleRepository : IPeopleRepository,IDisposable
    {
        private readonly LiteDatabase _db;

        public PeopleRepository(IPlatformInfoService dbpathService)
        {
            _db = LiteDBHelper.GetInstance(dbpathService.GetLiteDBFilePath());
        }
        public async Task<Person> AddAsync(Person person)
        {
            try
            {
                var collection = _db.GetCollection<Person>();
                collection.Insert(person);
                return person;
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool> DeleteAsync(Person person)
        {
            try
            {
                var collection = _db.GetCollection<Person>();
                collection.Delete(person.Id);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            try
            {
                var collection = _db.GetCollection<Person>();
                return collection.FindAll();
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            try
            {
                var collection = _db.GetCollection<Person>();
                collection.Update(person.Id, person);
                return person;
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
