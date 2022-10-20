using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Entities.Concrete.ComplexTypes
{
    public class Report
    {
        public string Location { get; set; }
        public int NumberOfLocation { get; set; }
        public int NumberOfPerson { get; set; }
        public int NumberOfPhoneNumber { get; set; }
    }
}
