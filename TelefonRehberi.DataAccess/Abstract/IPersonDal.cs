using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Concrete;
using TelefonRehberi.Entities.Concrete.ComplexTypes;

namespace TelefonRehberi.DataAccess.Abstract
{
    public interface IPersonDal : IEntityRepository<Person>
    {
        List<Report> GetPersonReport();
    }
}
