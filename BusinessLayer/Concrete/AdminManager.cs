﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin Authenticate(string username, string password)
        {
            var admin = _adminDal.Authenticate(username, password);
            return admin;
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x=>x.AdminId ==  id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
    }
}
