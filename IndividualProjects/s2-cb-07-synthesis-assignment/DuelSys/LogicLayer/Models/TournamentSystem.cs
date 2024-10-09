using LogicLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TournamentSystem
    {
        private int id;
        private string name;
        
        #region properties
        public int Id { get { return id; } }
        public string Name { get { return name; } set { name = value; } }

        #endregion
        public TournamentSystem(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
