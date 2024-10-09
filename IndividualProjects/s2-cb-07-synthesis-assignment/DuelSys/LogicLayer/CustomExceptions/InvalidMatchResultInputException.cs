using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CustomExceptions
{
    public class InvalidMatchResultInputException: Exception
    {
        public InvalidMatchResultInputException(string message)
            : base(message)
        {

        }
    }
}
