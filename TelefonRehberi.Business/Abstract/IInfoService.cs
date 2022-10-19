using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Concrete;

namespace TelefonRehberi.Business.Abstract
{
    public interface IInfoService
    {
        Info Add(Info info);
        void Delete(Info info);
        Info Update(Info info);
        Info GetById(Guid info);
        List<Info> GetAll();
    }
}
