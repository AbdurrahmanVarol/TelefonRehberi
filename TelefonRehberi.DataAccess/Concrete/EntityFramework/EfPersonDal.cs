using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities.Abstract;
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

        public Person GetDetail(Expression<Func<Person, bool>> filter)
        {
            return _context.Persons.Include(p=>p.Infos).FirstOrDefault(filter);
        }
        public List<Person> GetDetails(Expression<Func<Person, bool>> filter = null)
        {
            return filter == null ? _context.Persons.Include(p => p.Infos).ToList():_context.Persons.Include(p => p.Infos).Where(filter).ToList();
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
                        NumberOfPhoneNumber = (_context.Infos.Where(p=>p.InfoType==InfoType.PhoneNumber && 
                                                                       g.Select(q=>q.person.PersonId).Contains(p.PersonId)).Count())
                    }
                ).ToList();
        }
    }
}
