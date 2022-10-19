using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TelefonRehberi.API.Models;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Entities.Concrate;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;

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
        [Route("conroller/{personId}")]
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
                Company = personModel.Company,
                DirectoryId = personModel.DirectoryId
            };
            var addedPerson = _personService.Add(person);

            return Ok(addedPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonModel personModel)
        {
            if (personModel == null)
                return BadRequest();

            var person = new Person
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                Company = personModel.Company,
                DirectoryId = personModel.DirectoryId
            };
            var addedPerson = _personService.Update(person);

            return Ok(addedPerson);
        }

        [HttpDelete]
        [Route("controller/{personId}")]
        public IActionResult Delete(Guid personId)
        {
            var person = _personService.GetById(personId);
            if (person == null)
            {
                return NotFound();
            }
            _personService.Delete(person);
            return Ok();
        }
    }
}
