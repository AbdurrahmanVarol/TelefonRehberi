using Microsoft.AspNetCore.Mvc;
using System;
using TelefonRehberi.API.Models;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Core.Caching;
using TelefonRehberi.Entities.Concrete;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        private ICache _cache;

        public PersonsController(IPersonService personService, ICache cache)
        {
            _personService = personService;
            _cache = cache;
            _cache.Set("Persons", _personService.GetAll());

        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(_personService.GetAll());
            var inCacheList = _cache.Get<List<Person>>("Persons");
            
            if (inCacheList == null)
            {
                var list = _personService.GetAll();
                _cache.Set("Persons", list);
                return Ok(list);
            }
            return Ok(inCacheList);
        }

        [HttpGet]
        [Route("{personId}")]
        public IActionResult Get(Guid personId)
        {
            var person = _personService.GetById(personId);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonModel personModel)
        {
            if (personModel == null)
                return BadRequest();

            var person = new Person
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                Company = personModel.Company
            };
            var addedPerson = _personService.Add(person);

            var persons = _cache.Get<List<Person>>("Persons");

            persons.Add(person);

            _cache.Set("Persons", persons);

            return Ok(addedPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonModel personModel)
        {
            if (personModel == null)
                return BadRequest();

            var person = _personService.GetById(personModel.PersonId);
            if (person == null)
                return NotFound();

            person.FirstName = personModel.FirstName;
            person.LastName = personModel.LastName;
            person.Company = personModel.Company;

            var updatedPerson = _personService.Update(person);

            var persons = _cache.Get<List<Person>>("Persons");

            var index = persons.FindIndex(p => p.PersonId == person.PersonId);

            persons[index].FirstName = personModel.FirstName;
            persons[index].LastName = personModel.LastName;
            persons[index].Company = personModel.Company;

            _cache.Set("Persons", persons);

            return Ok(updatedPerson);
        }

        [HttpDelete]
        [Route("{personId}")]
        public IActionResult Delete(Guid personId)
        {
            var person = _personService.GetById(personId);
            if (person == null)
            {
                return NotFound();
            }
            _personService.Delete(person);
            return NoContent();
        }

        [HttpGet("report")]
        public IActionResult GetReport()
        {
            return Ok(_personService.GetPersonReport());
        }
    }
}
