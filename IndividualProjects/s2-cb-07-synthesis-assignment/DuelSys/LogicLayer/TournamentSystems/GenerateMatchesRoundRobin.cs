using LogicLayer.CustomExceptions;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class GenerateMatchesRoundRobin: IGenerateMatches
    {
        public List<TournamentMatch> GenerateMatches(Tournament tournament)
        {
            //depending on n we can devide persons to play home or away. this to avoid that some players only play at home
            int n = 0;
            List<TournamentMatch> matches = new List<TournamentMatch>();
            for (int i = 0; i < tournament.Users.Count; i++)
            {
                for (int j = i + 1; j < tournament.Users.Count; j++)
                {
                    if (n % 2 == 0)
                    {
                        matches.Add(new TournamentMatch(tournament.Id, tournament.Users[i].Id, tournament.Users[j].Id));
                    }
                    else
                    {
                        matches.Add(new TournamentMatch(tournament.Id, tournament.Users[j].Id, tournament.Users[i].Id));
                    }
                    n++;
                }
                n = 0;
            }
            return matches;
        }
        
    }
}
