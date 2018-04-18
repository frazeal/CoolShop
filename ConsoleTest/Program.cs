using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryMiddlayer;
using ICustomerInterface;
using Stratergy;
namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomer i = Factory<ICustomer>.Create("Lead");
            i.CustomerName = "Shiv";
            //i.Address = "Test";
            //i.BillAmount = 100;
            //i.BillDate = Convert.ToDateTime("1/1/2010");
            i.PhoneNumber = "3123";
            i.Validate();
        }
    }
}