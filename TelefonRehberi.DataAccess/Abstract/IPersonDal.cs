using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Concrete;
using TelefonRehberi.Entities.Concrete.ComplexTypes;

namespace TelefonRehberi.DataAccess.Abstract
{
    public interface IPersonDal : IEntityRepository<Person>
    {
        Person GetDetail(Expression<Func<Person, bool>> filter);
        List<Person> GetDetails(Expression<Func<Person, bool>> filter = null);
        List<Report> GetPersonReport();
    }
}
