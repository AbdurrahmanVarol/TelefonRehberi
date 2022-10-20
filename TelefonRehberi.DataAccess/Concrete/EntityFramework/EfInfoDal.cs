using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities.Concrete;

namespace TelefonRehberi.DataAccess.Concrete.EntityFramework
{
    public class EfInfoDal : EfEntityRepositoryBase<Info, TelefonRehberiContext>, IInfoDal
    {
        public EfInfoDal(TelefonRehberiContext context) : base(context)
        {
        }

    }
}
