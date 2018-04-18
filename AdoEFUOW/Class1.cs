using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDal;
using ICustomerInterface;
using System.Transactions;
namespace AdoEFUOW
{
    public class ADoEFUow : IUOW<BoBase>
    {
        TransactionScope scope;
        public IDataLayer<CustomerBase> CustomerDal;
        public IDataLayer<AddressBase> AddressDal;
        public IDataLayer<PhoneBase> PhoneDal;
        
        public void Committ()
        {
            try
            {
                using (scope = new TransactionScope())
                {
                    CustomerDal.SavetoDB();
                    
                    AddressDal.SavetoDB();
                    PhoneDal.SavetoDB();
                }
                scope.Complete();
            }
            catch (Exception ex)
            {
                Rollback();
            }
        }

        public void Rollback()
        {
            scope.Dispose();
        }




        public void Add(IDataLayer<BoBase> dal)
        {
            throw new NotImplementedException();
        }
    }
}
