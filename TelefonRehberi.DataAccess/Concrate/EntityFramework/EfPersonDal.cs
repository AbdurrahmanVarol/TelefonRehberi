using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities.Concrete;

namespace TelefonRehberi.DataAccess.Concrate.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, TelefonRehberiContext>, IPersonDal
    {
        public EfPersonDal(TelefonRehberiContext context) : base(context)
        {
        }
    }
}
