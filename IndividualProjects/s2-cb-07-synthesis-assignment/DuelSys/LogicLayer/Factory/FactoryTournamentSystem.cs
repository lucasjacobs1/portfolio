using LogicLayer.CustomExceptions;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public static class FactoryTournamentSystem
    {
        public static IGenerateMatches ReturnTournamentType(int TournamentTypeId)
        {
            IGenerateMatches generateMatches;
            switch (TournamentTypeId)
            {
                case (int)tournamentSystemTypes.RoundRobin:
                    generateMatches = new GenerateMatchesRoundRobin();
                    break;
                case (int)tournamentSystemTypes.DoubleRoundRobin:
                    generateMatches = new GenerateMatchesDoubleRoundRobin();
                    break;
                default: throw new TournamentGeneratorFailedException("This is not supposed to happen.");
            }
            return generateMatches;
        }
    }
}
