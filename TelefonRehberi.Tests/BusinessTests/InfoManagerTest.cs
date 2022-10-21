using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Business.Concrete;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.DataAccess.Concrete.EntityFramework;
using TelefonRehberi.Entities.Concrete;
using TelefonRehberi.Entities.Enums;

namespace TelefonRehberi.Tests.BusinessTests
{
    public class InfoManagerTest
    {
        private IInfoDal _ınfoDal;
        private IInfoService _infoService;
        private IPersonDal _personDal;
        private IPersonService _personService;
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
        }

        [Test]
        public void GetAll()
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
            var actual = _infoService.GetAll().Contains(info);

            var expected = true;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetById()
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
            var actual = _infoService.GetById(info.InfoId).InfoType;

            var expected = InfoType.Location;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add()
        {
            var person = _personService.Add(new Person
            {
                FirstName = "Farık",
                LastName = "Far",
                Company = "Faraf"
            });
            var actual = _infoService.Add(new Info
            {
                InfoType = InfoType.Location,
                Description = "Ankara",
                PersonId = person.PersonId
            });

            var expected = InfoType.Location;
            Assert.That(actual.InfoType, Is.EqualTo(expected));
        }

        [Test]
        public void Update()
        {
            var person = _personService.Add(new Person
            {
                PersonId = Guid.NewGuid(),
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

            info.Description = "Bursa";
            var actual = _infoService.Update(info).Description;

            var expected = "Bursa";
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Delete()
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
            _infoService.Delete(info);

            var actual = _infoService.GetAll().Contains(info);
            var expected = false;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
