using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ISportRules
    {
        bool ValidateRules(MatchResult matchResult);
    }
}
