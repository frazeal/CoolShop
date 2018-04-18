using CustomerLibrary;
using ICustomerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCustomer
{
    //Design pattern - Simple Factory
    public static class Factory
    {
        private static IList<ICustomer> customers = null;

        private static void LoadCustomers()
        {
            //Design patter - RIP
            customers = new List<ICustomer>();
            customers.Add(new Lead());
            customers.Add(new Customer());
        }

        public static ICustomer Create(int customerType)
        {
            if (customers == null)
            {
                LoadCustomers();
            }
            return customers[customerType];
        }
    }
}
