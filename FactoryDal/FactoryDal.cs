using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDal;
using FactoryDalLib;
using Microsoft.Practices.Unity;
using AdoDalLayer;
using ICustomerInterface;
using AbstractDal;
using EfDal;
using System.Data.Entity;
namespace FactoryDalLib
{
    public static class FactoryDal<AnyType>
    {
        static IUnityContainer container;
        public static IDataLayer<AnyType> getDal(string Daltype)
        {
            // Design pattern :- Lazy Loading ( Improve the below code using Lazy keyword).
            if(container==null)
            {
                container = new UnityContainer();
                container.RegisterType<IDataLayer<ICustomer>, CustomerDal>("AdoCustDal"); 
                container.RegisterType<IDataLayer<CustomerBase>, CustomerEfDal>("EfCustDal");

            // Design pattern :- RIP ( Replace IF with Polymorphism)
            }
            return (IDataLayer<AnyType>)container.Resolve<IDataLayer<AnyType>>(Daltype);
        }
    }
}
