﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CustomExceptions
{
    public class InvalidRegistrationTournamentInput:Exception
    {
        public InvalidRegistrationTournamentInput(string message)
            : base(message)
        {

        }
    }
}
