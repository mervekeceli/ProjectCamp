﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepositoryDal<Category>
    {
        //CRUD
        //Type Name();

        List<Category> List();
        void Insert(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
