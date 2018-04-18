using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICustomerInterface;
using IDal;
using FactoryMiddlayer;
using CustomerLibrary;
using FactoryDalLib;
namespace Mediator
{
    public class Mediator 
    {
        private CustomerAddress cust = new CustomerAddress();

      
        public Mediator(IDataLayer<CustomerBase> _CustomerDal,
                        IDataLayer<AddressBase> _AddressDal,
                        IDataLayer<PhoneBase> _PhoneDal)
        {
            CustomerDal = _CustomerDal;
            AddressDal = _AddressDal;
            PhoneDal = _PhoneDal;
        }
        private IDataLayer<CustomerBase> CustomerDal;
        private IDataLayer<AddressBase> AddressDal;
        private IDataLayer<PhoneBase> PhoneDal;
        
        public void Add(CustomerBase obj)
        {
            // Automapper
            cust.CustomerName = obj.CustomerName;
            cust.BillAmount = obj.BillAmount;
            cust.BillDate = obj.BillDate;
            cust.Address = obj.Address;
        }
        public void Add(AddressBase obj)
        {
            AddressPhone i = new AddressPhone();
            i.Address1 = obj.Address1;
            cust.Addresses.Add(i);
        }
        public void Add(PhoneBase phone, int index)
        {
            Phone p = new Phone();
            p.PhoneNumber = phone.PhoneNumber;
            cust.Addresses[index].Phones.Add(p);
        }
        public void SaveAll()
        {
            AdoEFUOW.ADoEFUow o = new AdoEFUOW.ADoEFUow();
            
            o.CustomerDal = CustomerDal;
            o.AddressDal = AddressDal;
            o.PhoneDal = PhoneDal;
            CustomerBase y = Factory<CustomerBase>.Create(cust.Type);
            y.Id = cust.Id;
            y.CustomerName = cust.CustomerName;
            y.PhoneNumber = cust.PhoneNumber;
            y.Address = cust.Address;
            y.BillAmount = cust.BillAmount;
            y.BillDate = cust.BillDate;
            CustomerDal.AddInMemory(y);
            
            foreach (AddressPhone a in cust.Addresses)
            {
                AddressBase a1 = Factory<AddressBase>.Create("Address");
                a1.Address1 = a.Address1;
                AddressDal.AddInMemory((AddressBase) a);
                foreach (PhoneBase i in a.Phones)
                {
                    PhoneDal.AddInMemory((PhoneBase) i);
                }
            }
            o.Committ();
        }
    }
}
