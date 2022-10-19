using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TelefonRehberi.API.Models;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Entities.Concrete;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.GetAll());
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

        //GET
        //Persons/5/CommunicationInfo

        //CommunicatioInfo (Body Person Id : 5)

        // Persons/CommunicationInfo

    }
}
