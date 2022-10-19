using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities.Concrete;

namespace TelefonRehberi.Business.Concrate
{
    public class InfoManager : IInfoService
    {
        private readonly IInfoDal _infoDal;

        public InfoManager(IInfoDal infoDal)
        {
            _infoDal = infoDal;
        }

        public Info Add(Info info)
        {
            return _infoDal.Add(info);
        }

        public void Delete(Info info)
        {
            _infoDal.Delete(info);
        }

        public List<Info> GetAll()
        {
            return _infoDal.GetAll();
        }

        public Info GetById(Guid infoId)
        {
            return _infoDal.Get(p => p.InfoId == infoId);
        }

        public Info Update(Info info)
        {
            return _infoDal.Update(info);
        }
    }
}
