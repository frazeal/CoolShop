using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryMiddlayer;
using FactoryDalLib;
using ICustomerInterface;
using IDal;
namespace Facade
{
    public class CustomerUiFacade
    {
        IDataLayer<ICustomer> dal;
        private CustomerBase custOld; // Design pattern :- Memento pattern
        List<ICustomer> custcoll;
        int SelectedIndex=0;
        public CustomerUiFacade(string DalType)
        {
            dal = FactoryDal<ICustomer>.getDal(DalType);
        }
        public ICustomer Get(string Type)
        {
            return Factory<ICustomer>.Create(Type);
        }
        public ICustomer Revert()
        {
            return custcoll[SelectedIndex].Clone();
        }
        public ICustomer Select(int Index)
        {
            SelectedIndex = Index;
            return custcoll[Index].Clone();

        }
        public List<ICustomer> GetCustomers()
        {
            custcoll = dal.Get();
            return custcoll;
        }
        public void Save(ICustomer Base)
        {
            // Design pattern :- Facade pattern
            Base.Validate();
            dal.Add(Base);
            dal.Save();
        }
    }
}
