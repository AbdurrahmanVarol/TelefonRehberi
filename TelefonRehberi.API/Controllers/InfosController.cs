using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.API.Models;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Entities.Concrete;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfosController : ControllerBase
    {
        private readonly IInfoService _infoService;

        public InfosController(IInfoService infoService)
        {
            _infoService = infoService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_infoService.GetAll());
        }
        [HttpGet("{infoId}")]
        public IActionResult Get(Guid infoId)
        {
            var info = _infoService.GetById(infoId);
            if (info == null)
                return NotFound();

            return Ok(info);
        }
        [HttpPost]
        public IActionResult Post([FromBody] InfoModel infoModel)
        {
            if (infoModel == null)
                return BadRequest();
            if (infoModel.PersonId == default(Guid))
                return BadRequest();
            var info = new Info
            {
                InfoType = infoModel.InfoType,
                Description = infoModel.Description,
                PersonId = infoModel.PersonId,
            };
            var addedInfo = _infoService.Add(info);
            return Ok(addedInfo);
        }

        [HttpPut]
        public IActionResult Put([FromBody] InfoModel infoModel)
        {
            if (infoModel == null)
                return BadRequest();
            if (infoModel.PersonId == default(Guid))
                return BadRequest();

            var info = _infoService.GetById(infoModel.InfoId);
            if (info == null)
                return NotFound();

            info.InfoType = infoModel.InfoType;
            info.Description = infoModel.Description;
            info.PersonId = infoModel.PersonId;

            var updatedInfo = _infoService.Update(info);
            return Ok(updatedInfo);
        }

        [HttpDelete("{infoId}")]
        public IActionResult Delete(Guid infoId)
        {
            var info = _infoService.GetById(infoId);
            if (info == null)
                return NotFound();
            _infoService.Delete(info);
            return NoContent();
        }
    }
}
