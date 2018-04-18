using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDal
{
    // Design pattern :- Repository Pattern
    public interface IDataLayer<AnyType>
    {
        
        void Add(AnyType obj);
        void Delete(AnyType obj);
        void Save();
        List<AnyType> Get();
      
    }
    
  
}
