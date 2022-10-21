using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Abstract;

namespace TelefonRehberi.Entities.Concrete
{
    public class Person : IEntity
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public ICollection<Info> Infos { get; set; }
    }
}
