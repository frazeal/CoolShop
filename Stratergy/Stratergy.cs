using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stratergy
{
    public interface IValidationStratergy<AnyType>
    {
        void Validate(AnyType obj);
    }
}
