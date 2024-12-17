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
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        Context context = new Context();
        DbSet<Admin> _object;

        public EfAdminDal()
        {
            _object = context.Set<Admin>();
        }

        public Admin Authenticate(string userName, string password)
        {
            return _object.FirstOrDefault(x=>x.AdminUserName == userName && x.AdminPassword == password);
        }
    }
}
