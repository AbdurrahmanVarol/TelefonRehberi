using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DataAccess.Abstract;

namespace TelefonRehberi.DataAccess.Concrate.EntityFramework
{
    public class EfDirectoryDal : EfEntityRepositoryBase<Entities.Concrate.Directory, TelefonRehberiContext>, IDirectoryDal
    {
        public EfDirectoryDal(TelefonRehberiContext context) : base(context)
        {
        }
    }
}
