using LogicLayer.CustomExceptions;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class BadmintonRules: ISportRules
    {
        public bool ValidateRules(MatchResult matchResult)
        {
            if (matchResult.PlayerHomeScore >= 0 && matchResult.PlayerAwayScore >= 0)
            {
                if (matchResult.PlayerHomeScore == 21 && matchResult.PlayerAwayScore < 20 || matchResult.PlayerAwayScore == 21 && matchResult.PlayerHomeScore < 20)//this is the most common result
                {
                    //add match
                    return true;
                }
                else if (matchResult.PlayerHomeScore >= 20 && matchResult.PlayerAwayScore >= 20)
                {
                    if (matchResult.PlayerHomeScore < 30 && matchResult.PlayerAwayScore < 30) //this is after the first if statement the most common
                    {
                        if (matchResult.PlayerHomeScore - matchResult.PlayerAwayScore == 2 || matchResult.PlayerAwayScore - matchResult.PlayerHomeScore == 2)
                        {
                            //add match
                            return true;
                        }
                    }
                    else if (matchResult.PlayerHomeScore == 30 || matchResult.PlayerAwayScore == 30)// this is the least common result
                    {
                        if (matchResult.PlayerHomeScore - matchResult.PlayerAwayScore == 1 || matchResult.PlayerAwayScore - matchResult.PlayerHomeScore == 1)
                        {
                            //addmatch 
                            return true;
                        }
                    }
                }
            }
            throw new InvalidMatchResultInputException("Match score is not correct");
        }
    }
}
