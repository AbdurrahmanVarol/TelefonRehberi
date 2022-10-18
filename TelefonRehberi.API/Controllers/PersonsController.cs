using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            var addedPerson = _personService.Add(person);

            return Ok(addedPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            var updatedPerson = _personService.Update(person);

            return Ok(updatedPerson);
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
