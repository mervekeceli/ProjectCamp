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
    public class EfContentDal : GenericRepository<Content>, IContentDal
    {
        //Gözden Geçir
        Context context = new Context();
        DbSet<Content> _object;

        public EfContentDal()
        {
            _object = context.Set<Content>();
        }

        public override List<Content> List()
        {
            return _object.Include(x => x.Writer).Include(y => y.Heading).ToList();
        }

        public override List<Content> List(Expression<Func<Content, bool>> filter)
        {
            return _object.Where(filter).Include(x=>x.Writer).Include(y=>y.Heading).ToList();
        }
    }
}
