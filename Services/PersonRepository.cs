using Labb_4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Labb_4.Services
{
    public class PersonRepository : IPersonRepository<Person>
    {
        //_appContext to grab data from specified table
        private AppDbContext _appContext;
        public PersonRepository(AppDbContext appContext)
        {
            this._appContext = appContext;
        }

        public async Task<Person> Add(Person newEntity)
        {
            var result = await _appContext.Persons.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> Delete(int id)
        {
            var result = await _appContext.Persons.FirstOrDefaultAsync(p => p.ID == id);
            if(result != null)
            {
                _appContext.Persons.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            //Hämtar allt
            return await _appContext.Persons.ToListAsync();
        }

        public async Task<Person> GetSingle(int id)
        {
            return await _appContext.Persons.FirstOrDefaultAsync(p => p.ID == id); //Hämtar single person via ID
        }

        public async Task<Person> Update(Person Entity) 
        {
            var result = await _appContext.Persons.FirstOrDefaultAsync(p => p.ID == Entity.ID);
            if(result != null)
            {
                result.Name = Entity.Name;
                result.Phone = Entity.Phone;
                
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<PersonHobbysDto>> GetPersonHobby(int id)
        {
            var person = await _appContext.Persons.FindAsync(id);//Retrieves a person from the person Table using id
            if (person == null)
            {
                return null;
            }

            var links = await _appContext.Links         //Retrieves data from Link Table
                .Include(link => link.Hobby)            //this includes the the link to Hobby
                .Where(link => link.PersonID == id)     //Filters based on the personID so it matches with ID
                .ToListAsync();                         //Retreieves the data as a list asynchronously

            var personHobbysDtos = links.Select(link => new PersonHobbysDto
            {
                //Sätter props av personhobbydto objects baserat på Link och Person Information
                PersonID = person.ID,
                PersonName = person.Name,
                hobbys = link.Hobby
            });

            return personHobbysDtos;
        }

        public async Task<IEnumerable<Link>> GetPersonLinks(int id)
        {
            var links = await _appContext.Links //Hämtar alla länkar till 
                .Where(l => l.PersonID == id)
                .ToListAsync();

            return links; //retunerar en lista av Link pga IEnumerable
        }

        public async Task<ActionResult<Link>> Update(Link link)
        {
            var result = await _appContext.Links.FirstOrDefaultAsync(l => l.ID == link.ID); //Hittar link entities baserat på ID

            if (result != null)
            {
                //Uppdaterar link entities som finns med nya values från input link object
                result.LinkName = link.LinkName; 
                result.URL = link.URL;
                result.HobbyID = link.HobbyID;
                result.PersonID = link.PersonID;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<Person> AddNewLinkForPerson(int personID, string urlLink, int hobbyID)
        {
            var person = await _appContext.Persons.FindAsync(personID);//Hittar person entities baserat på ID
            if (person == null)
            {
                return null;
            }

            var link = new Link //Skapar ny link entity
            {
                //Här sätts nya värden för det nya entity
                PersonID = personID, 
                URL = urlLink,
                HobbyID = hobbyID
            };

            await _appContext.Links.AddAsync(link); // lägger till
            await _appContext.SaveChangesAsync(); // Sparar till databasen
            return person;
        }
    }
}
