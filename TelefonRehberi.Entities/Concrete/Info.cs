using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Abstract;
using TelefonRehberi.Entities.Enums;

namespace TelefonRehberi.Entities.Concrete
{
    public class Info : IEntity
    {
        public Guid InfoId { get; set; }
        public InfoType InfoType { get; set; }
        public string Description { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
