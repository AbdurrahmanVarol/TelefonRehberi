using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.API.Controllers;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Business.Concrete;
using TelefonRehberi.Core.Caching;
using TelefonRehberi.Core.Caching.Redis;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.DataAccess.Concrete.EntityFramework;

namespace TelefonRehberi.Tests.APITests
{
    public class PersonControllerTest
    {
        private IInfoDal _ınfoDal;
        private IInfoService _infoService;
        private IPersonDal _personDal;
        private IPersonService _personService;
        private ICache _cache;
        private PersonsController _personsController;

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
            var config = new Dictionary<string, string>
            {
                {"RedisConfiguration:ConnectionString", "localhost:6379"},
            };
            var configuration = new ConfigurationBuilder()
                                .AddInMemoryCollection(config)
                                .Build();
            _cache = new RedisCache(configuration);

            _personsController = new PersonsController(_personService, _cache);
        }
        [Test]
        public void Post_WithNullObject_BadRequest()
        {
            var actual = _personsController.Post(null) as BadRequestResult;

            var expected = (int)HttpStatusCode.BadRequest;

            Assert.That(actual.StatusCode, Is.EqualTo(expected));
        }
    }
}
