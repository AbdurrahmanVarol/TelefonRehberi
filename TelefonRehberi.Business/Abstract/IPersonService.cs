using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Concrete;
using TelefonRehberi.Entities.Concrete.ComplexTypes;

namespace TelefonRehberi.Business.Abstract
{
    public interface IPersonService
    {
        Person Add(Person person);
        void Delete(Person person);
        Person Update(Person person);
        Person GetById(Guid personId);
        List<Person> GetAll();
        Person GetDetailById(Guid personId);
        List<Person> GetDetails();
        List<Report> GetPersonReport();
    }
}
