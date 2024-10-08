﻿using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Abstract
{
    public interface ICustomerAccounProcessDal:IGenericDal<CustomerAccountProcess>
    {
        List<CustomerAccountProcess> MyLastProcess(int id);
    }
}
