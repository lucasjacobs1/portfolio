using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CustomExceptions
{
    public class InvalidLoginInputException: Exception
    {
        public InvalidLoginInputException(string message)
            : base(message)
        {

        }
    }
}
