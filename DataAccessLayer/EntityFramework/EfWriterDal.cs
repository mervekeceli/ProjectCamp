using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        Context context = new Context();
        DbSet<Writer> _object;

        public EfWriterDal()
        {
            _object = context.Set<Writer>();
        }

        public Writer Authenticate(string writerMail, string password)
        {
            return _object.FirstOrDefault(x => x.WriterEmail == writerMail && x.WriterPassword == password);
        }
    }
}
