using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DataAccess.Abstract;

namespace TelefonRehberi.DataAccess.Concrate.EntityFramework
{
    public class EfDirectoryDal : IDirectoryDal
    {
        public Entities.Concrate.Directory Add(Entities.Concrate.Directory entity)
        {
            throw new NotImplementedException();
        }

        public Entities.Concrate.Directory Delete(Entities.Concrate.Directory entity)
        {
            throw new NotImplementedException();
        }

        public Entities.Concrate.Directory Get(Expression<Func<Entities.Concrate.Directory, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Entities.Concrate.Directory> GetAll(Expression<Func<Entities.Concrate.Directory, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Entities.Concrate.Directory Update(Entities.Concrate.Directory entity)
        {
            throw new NotImplementedException();
        }
    }
}
