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
    public class PersonManagerTest
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
            var actual = _personService.GetAll().Contains(person);

            var expected = true;
            Assert.AreEqual(expected, actual);
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
            var actual = _personService.GetById(person.PersonId).FirstName;

            var expected = "Farık";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDetails()
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
            var actual = _personService.GetDetails().Contains(person);

            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDetailsById()
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
            var actual = _personService.GetDetailById(person.PersonId).FirstName;

            var expected = "Farık";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add()
        {
            var actual = _personService.Add(new Person
            {
                FirstName = "Farık",
                LastName = "Far",
                Company = "Faraf"
            });


            var expected = "Farık";
            Assert.AreEqual(expected, actual.FirstName);
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

            person.FirstName = "Sadık";
            var actual = _personService.Update(person).FirstName;

            var expected = "Sadık";
            Assert.AreEqual(expected, actual);
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
            _personService.Delete(person);

            var actual = _personService.GetById(person.PersonId);
            Assert.AreEqual(null, actual);
        }
    }
}
