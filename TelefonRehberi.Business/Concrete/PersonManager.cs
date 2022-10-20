using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities.Concrete;
using TelefonRehberi.Entities.Concrete.ComplexTypes;

namespace TelefonRehberi.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public Person Add(Person person)
        {
            return _personDal.Add(person);
        }

        public void Delete(Person person)
        {
            _personDal.Delete(person);
        }

        public List<Person> GetAll()
        {
            return _personDal.GetAll();
        }

        public Person GetById(Guid personId)
        {
            return _personDal.Get(p => p.PersonId == personId);
        }

        public List<Report> GetPersonReport()
        {
            return _personDal.GetPersonReport();
        }

        public Person Update(Person person)
        {
            return _personDal.Update(person);
        }
    }
}
