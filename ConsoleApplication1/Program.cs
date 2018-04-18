using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryDalLib;
using FactoryMiddlayer;
using Mediator;
using ICustomerInterface;
using IDal;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataLayer<CustomerBase> dalcust = FactoryDal<CustomerBase>.getDal("EfCustDal");
            IDataLayer<AddressBase> daladd = FactoryDal<AddressBase>.getDal("EfAddDal");
            IDataLayer<PhoneBase> dalphone = FactoryDal<PhoneBase>.getDal("EfPhoneDal");
            Mediator.Mediator obj = new Mediator.Mediator(dalcust,daladd,dalphone);
            CustomerBase c = Factory<CustomerBase>.Create("Customer");
            c.CustomerName = "tesy123";
            c.PhoneNumber = "90909";
            c.BillDate = Convert.ToDateTime("1/1/2010");
            c.Type = "Customer";
            c.BillAmount = 100;
            obj.Add(c);
            AddressBase a = Factory<AddressBase>.Create("Address");
            a.Address1 = "Mulund";
            obj.Add(a);
            PhoneBase p  = Factory<PhoneBase>.Create("Phone");
            p.PhoneNumber = "222";
            obj.Add(p, 0);
            obj.SaveAll();
        }
    }
}
