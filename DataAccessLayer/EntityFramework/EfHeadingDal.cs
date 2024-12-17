using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
        //Gözden Geçir
        Context context = new Context();
        DbSet<Heading> _object;

        public EfHeadingDal()
        {
            _object = context.Set<Heading>();
        }
        public override List<Heading> List()
        {
            return _object.Include(x=>x.Writer).Include(y=>y.Category).ToList();
        }

        public override List<Heading> List(Expression<Func<Heading, bool>> filter)
        {
            return _object.Include(x=>x.Writer).Include(x=>x.Category).Where(filter).ToList();
        }
    }
}
