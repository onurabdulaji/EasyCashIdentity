using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.BusinessLayer.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccount t)
        {
            //throw new NotImplementedException();
            _customerAccountDal.Delete(t);
        }

        public CustomerAccount TGetByID(int id)
        {
            //throw new NotImplementedException();
            return _customerAccountDal.GetByID(id);
        }

        public List<CustomerAccount> TGetList()
        {
            //throw new NotImplementedException();
            return _customerAccountDal.GetList();
        }

        public void TInsert(CustomerAccount t)
        {
            //throw new NotImplementedException();
            _customerAccountDal.Insert(t);
        }

        public void TUpdate(CustomerAccount t)
        {
            //throw new NotImplementedException();
            _customerAccountDal.Update(t);
        }
    }
}
