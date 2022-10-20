﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities.Concrete;
using TelefonRehberi.Entities.Concrete.ComplexTypes;
using TelefonRehberi.Entities.Enums;

namespace TelefonRehberi.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, TelefonRehberiContext>, IPersonDal
    {
        private readonly TelefonRehberiContext _context;
        public EfPersonDal(TelefonRehberiContext context) : base(context)
        {
            _context = context;
        }

        public List<Report> GetPersonReport()
        {
            return (from person in _context.Persons
                    join info in _context.Infos on person.PersonId equals info.PersonId
                    where info.InfoType == InfoType.Location
                    group new { person, info } by new { info.Description } into g
                    orderby g.Count() descending
                    select new Report
                    {
                        Location = g.Key.Description,
                        NumberOfLocation = g.Count(),
                        NumberOfPerson = g.Select(p => p.person).Count(),
                        NumberOfPhoneNumber = (_context.Infos.Where(p=>p.InfoType==InfoType.PhoneNumber && g.Select(q=>q.person).Select(q=>q.PersonId).Contains(p.PersonId)).Count())
                    }
                ).ToList();
        }
    }
}
