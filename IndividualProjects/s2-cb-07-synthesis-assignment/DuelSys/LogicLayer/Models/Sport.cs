using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Sport
    {
        private int id;
        private string name;

        public int Id { get { return id; } }
        public string Name { get { return name; } set { name = value; } }

        public Sport(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public ISportRules ValidateSportRules()
        {
            return FactorySportRules.ReturnSportRules(this.Id);
        }
    }
}
