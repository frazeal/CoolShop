using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICustomerInterface;
using Stratergy;
namespace CustomerLibrary
{
    
    public class Customer : CustomerBase
    {
        public Customer(IValidationStratergy<ICustomer> obj)  : base(obj)
        {
            
        }
        public override string Type
        {
            get
            {
                return "Customer";
            }
            set
            {
                _type = value;
            }
        }
        
    }
    public class Lead : CustomerBase
    {
        public Lead(IValidationStratergy<ICustomer> obj): base(obj)
        {

        }
        public override string Type
        {
            get
            {
                return "Lead";
            }
            set
            {
                _type = value;
            }
        }
       
    }
   

    
}
