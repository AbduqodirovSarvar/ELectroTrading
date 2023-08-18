using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        
        public NotFoundException() { }
        public NotFoundException(string _message)
            : base(_message) { }

    }
}
