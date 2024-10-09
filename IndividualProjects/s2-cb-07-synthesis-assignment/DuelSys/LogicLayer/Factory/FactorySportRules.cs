using LogicLayer.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public static class FactorySportRules
    {
        public static ISportRules ReturnSportRules(int sportId)
        {
            ISportRules sportRules;
            switch (sportId)
            {
                case (int)SportTypes.Badminton:
                    sportRules = new BadmintonRules();
                    break;
                default: throw new InvalidMatchResultInputException("This should not happen");
            }
            return sportRules;
        }
    }
}
