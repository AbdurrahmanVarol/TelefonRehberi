using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.API.Controllers;
using TelefonRehberi.API.Models;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Business.Concrete;
using TelefonRehberi.Core.Caching;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.DataAccess.Concrete.EntityFramework;
using TelefonRehberi.Entities.Concrete;
using TelefonRehberi.Entities.Enums;

namespace TelefonRehberi.Tests.APITests
{
    public class InfosControllerTest
    {
        private IInfoDal _ınfoDal;
        private IInfoService _infoService;
        private IPersonDal _personDal;
        private IPersonService _personService;
        private ICache _cache;
        private InfosController _infosController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TelefonRehberiContext>()
          .UseInMemoryDatabase(databaseName: "TelefonRehberiDb")
          .Options;

            _ınfoDal = new EfInfoDal(new TelefonRehberiContext(options));
            _infoService = new InfoManager(_ınfoDal);
            _personDal = new EfPersonDal(new TelefonRehberiContext(options));
            _personService = new PersonManager(_personDal);

            _infosController = new InfosController(_infoService);
        }

        [Test]
        public void Post_WithNullObject_BadRequest()
        {
            var actual= _infosController.Post(null) as BadRequestResult;

            var expected = (int)HttpStatusCode.BadRequest;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void Post_WithDefaultPersonId_BadRequest()
        {
            var actual= _infosController.Post(new InfoModel { PersonId = default(Guid)}) as BadRequestResult;

            var expected = (int)HttpStatusCode.BadRequest;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void Post_Ok()
        {
            var person = _personService.Add(new Person
            {
                FirstName = "Farık",
                LastName = "Far",
                Company = "Faraf"
            });
            var actual= _infosController.Post(new InfoModel { InfoType = (Entities.Enums.InfoType)1, Description = "asd",PersonId=person.PersonId }) as OkObjectResult;

            var expected = (int)HttpStatusCode.OK;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void Put_WithNullObject_BadRequest()
        {
            var actual= _infosController.Put(null) as BadRequestResult;

            var expected = (int)HttpStatusCode.BadRequest;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void Put_WithDefaultPersonId_BadRequest()
        {
            var actual= _infosController.Put(new InfoModel { PersonId = default(Guid)}) as BadRequestResult;

            var expected = (int)HttpStatusCode.BadRequest;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void Put_Ok()
        {
            var person = _personService.Add(new Person
            {
                FirstName = "Farık",
                LastName = "Far",
                Company = "Faraf"
            });
            var info = _infoService.Add(new Info
            {
                InfoType = InfoType.Location,
                Description = "Ankara",
                PersonId = person.PersonId
            });
            var infoModel = new InfoModel {
                InfoId = info.InfoId,
                InfoType = info.InfoType,
                Description = "Bursa",
                PersonId = info.PersonId
            };
            var actual= _infosController.Put(infoModel) as OkObjectResult;

            var expected = (int)HttpStatusCode.OK;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void Get_Ok()
        {

            var actual= _infosController.Get() as OkObjectResult;

            var expected = (int)HttpStatusCode.OK;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }

        [Test]
        public void Get_WithParameter_Ok()
        {
            var person = _personService.Add(new Person
            {
                FirstName = "Farık",
                LastName = "Far",
                Company = "Faraf"
            });

            var actual= _infosController.Get(person.PersonId) as OkObjectResult;

            var expected = (int)HttpStatusCode.OK;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }
        [Test]
        public void Delete_NotFound()
        {
            var actual= _infosController.Delete(Guid.NewGuid()) as NotFoundResult;

            var expected = (int)HttpStatusCode.NotFound;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }
        [Test]
        public void Delete_NoContent()
        {
            var person = _personService.Add(new Person
            {
                FirstName = "Farık",
                LastName = "Far",
                Company = "Faraf"
            });
            var info = _infoService.Add(new Info
            {
                InfoType = InfoType.Location,
                Description = "Ankara",
                PersonId = person.PersonId
            });

            var actual= _infosController.Delete(info.InfoId) as NoContentResult;

            var expected = (int)HttpStatusCode.NoContent;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }

    }
}
