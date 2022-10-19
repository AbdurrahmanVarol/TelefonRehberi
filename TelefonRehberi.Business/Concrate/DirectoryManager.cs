using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.DataAccess.Abstract;

namespace TelefonRehberi.Business.Concrate
{
    public class DirectoryManager : IDirectoryService
    {
        private IDirectoryDal _directoryDal;

        public DirectoryManager(IDirectoryDal directoryDal)
        {
            _directoryDal = directoryDal;
        }

        public Entities.Concrate.Directory Add(Entities.Concrate.Directory directory)
        {
            return _directoryDal.Add(directory);
        }

        public void Delete(Entities.Concrate.Directory directory)
        {
            _directoryDal.Delete(directory);
        }

        public List<Entities.Concrate.Directory> GetAll()
        {
            return _directoryDal.GetAll();
        }

        public Entities.Concrate.Directory GetById(Guid directoryId)
        {
            return _directoryDal.Get(p=>p.DirectoryId == directoryId);
        }

        public Entities.Concrate.Directory Update(Entities.Concrate.Directory directory)
        {
            return _directoryDal.Update(directory);
        }
    }
}
