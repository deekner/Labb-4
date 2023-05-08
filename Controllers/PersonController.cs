using Labb_4.Models;
using Labb_4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Labb_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository<Person> _personRepository;
        public PersonController(IPersonRepository<Person> labbFour)
        {
            this._personRepository = labbFour;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _personRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to Get all data from database");               
            }            
        }

        [HttpGet("{id}/Hobby")]
        public async Task<ActionResult<PersonHobbysDto>> GetPersonHobby(int id)
        {
            var personHobby = await _personRepository.GetPersonHobby(id);

            if (personHobby == null)
            {
                return NotFound();
            }
            return Ok(personHobby);
        }

        [HttpGet("{id}/Links")]
        public async Task<IActionResult> GetPersonLinks(int id)
        {
            try
            {
                var links = await _personRepository.GetPersonLinks(id);
                return Ok(links); 

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to Get all data from database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Link>> Update(int id, Link link)
        {
            try
            {
                if(id != link.ID)
                {
                    return BadRequest("Link is no match");
                }

                var UpdatePersonHobby = await _personRepository.GetSingle(id);
                if(UpdatePersonHobby == null)
                {
                    return NotFound("Link ID not found");
                }
                return await _personRepository.Update(link);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("persons/{personId}/links")]
        public async Task<IActionResult> AddLinkForPerson(int personId, string urlLink, int hobbyId)
        {
            try
            {
                var person = await _personRepository.GetSingle(personId); //Hämtar single ID
                if (person == null)
                {
                    return NotFound($"Person with ID {personId} not found");
                }

                await _personRepository.AddNewLinkForPerson(personId, urlLink, hobbyId);

                return Ok(person);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding link for person");
            }
        }


    }
}
