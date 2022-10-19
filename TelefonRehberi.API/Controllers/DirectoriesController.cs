using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.API.Models;
using TelefonRehberi.Business.Abstract;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoriesController : ControllerBase
    {
        private IDirectoryService _directoryService;

        public DirectoriesController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_directoryService.GetAll());
        }
        [HttpGet]
        [Route("conroller/{directoryId}")]
        public IActionResult Get(Guid directoryId)
        {
            var directory = _directoryService.GetById(directoryId);
            if (directory == null)
                return NotFound();
            return Ok(directory);
        }
        [HttpPost]
        public IActionResult Post(DirectoryModel directoryModel)
        {
            if (directoryModel == null)
                return BadRequest();

            var addedDirectory = _directoryService.Add(new Entities.Concrate.Directory
            {
                DirectoryId = directoryModel.DirectoryId
            });
            return Ok(addedDirectory);
        }
        [HttpGet]
        [Route("controller/{directoryId}")]
        public IActionResult Delete(Guid directoryId)
        {
            var directory = _directoryService.GetById(directoryId);
            if (directory == null)
                return NotFound();
            _directoryService.Delete(directory);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(DirectoryModel directoryModel)
        {
            if (directoryModel == null)
                return BadRequest();

            var updatedDirectory = _directoryService.Update(new Entities.Concrate.Directory
            {
                DirectoryId = directoryModel.DirectoryId
            });
            return Ok(updatedDirectory);
        }
    
    }
}
