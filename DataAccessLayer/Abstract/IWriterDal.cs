using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWriterDal : IRepositoryDal<Writer>
    {
        Writer Authenticate(string writerMail, string password);
    }
}
