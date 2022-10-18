using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities.Concrate;

namespace TelefonRehberi.DataAccess.Concrate.EntityFramework
{
    public class EfPersonDal : IPersonDal
    {
        public Person Add(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person Delete(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person Get(Expression<Func<Person, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll(Expression<Func<Person, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
