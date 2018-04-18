using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICustomerInterface;
using CustomerLibrary;
using Microsoft.Practices.Unity;
using ValidationStratergy;
using Stratergy;
namespace FactoryMiddlayer
{
    
    public static class Factory<AnyType>
    {
        static IUnityContainer container = null;

        public static AnyType Create(string Type)
        {
            if (container == null)
            {
                container = new UnityContainer();

                container.RegisterType<ICustomer, Customer>("Customer", 
                                new InjectionConstructor(new CustomerAllValidation()));
                container.RegisterType<ICustomer, Lead>("Lead", 
                                    new InjectionConstructor(new LeadValidation()));

            }
            return container.Resolve<AnyType>(Type.ToString());
        }
        
    }
}
