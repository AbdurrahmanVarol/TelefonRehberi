using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Abstract;

namespace TelefonRehberi.Entities.Concrate
{
    public class Directory : IEntity
    {
        public Guid DirectoryId { get; set; }

        public ICollection<Person> People { get; set; }
    }
}
