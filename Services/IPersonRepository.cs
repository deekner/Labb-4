using Labb_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb_4.Services
{
    public interface IPersonRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
        Task<IEnumerable<PersonHobbysDto>> GetPersonHobby(int id);
        Task<IEnumerable<Link>> GetPersonLinks(int id);
        Task<ActionResult<Link>> Update(Link link);
        Task<Person> AddNewLinkForPerson(int personID, string urlLink, int hobbyID);
    }
}
