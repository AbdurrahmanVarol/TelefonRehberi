using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Concrate;

namespace TelefonRehberi.Business.Abstract
{
    public interface IDirectoryService
    {
        Entities.Concrate.Directory Add(Entities.Concrate.Directory directory);
        void Delete(Entities.Concrate.Directory directory);
        Entities.Concrate.Directory Update(Entities.Concrate.Directory directory);
        Entities.Concrate.Directory GetById(Guid directoryId);
        List<Entities.Concrate.Directory> GetAll();
    }
}
