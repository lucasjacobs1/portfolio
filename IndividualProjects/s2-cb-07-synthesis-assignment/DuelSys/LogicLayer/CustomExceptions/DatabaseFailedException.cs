using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CustomExceptions
{
    public class DatabaseFailedException: Exception
    {
        public DatabaseFailedException(string message)
            : base(message)
        {

        }
    }
}
