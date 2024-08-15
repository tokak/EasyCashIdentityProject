using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccounProcessDal _customerAccounProcessDal;

        public CustomerAccountProcessManager(ICustomerAccounProcessDal customerAccounProcessDal)
        {
            _customerAccounProcessDal = customerAccounProcessDal;
        }

        public void TDelete(CustomerAccountProcess t)
        {
          _customerAccounProcessDal.Delete(t);
        }

        public CustomerAccountProcess TGetByID(int id)
        {
            return _customerAccounProcessDal.GetByID(id);
        }

        public List<CustomerAccountProcess> TGetList()
        {
            return _customerAccounProcessDal.GetList();
        }

        public void TInsert(CustomerAccountProcess t)
        {
            _customerAccounProcessDal.Insert(t);
        }

        public void TUpdate(CustomerAccountProcess t)
        {
            _customerAccounProcessDal.Update(t);
        }
    }
}
