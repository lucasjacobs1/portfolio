using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class SportAdmin
    {
        private ISportService _SportAdmin;
        public SportAdmin(ISportService sportAdmin)
        {
            _SportAdmin = sportAdmin;
        }
        public List<Sport> GetAllSports()
        {
            return _SportAdmin.GetAllSports();
        }
    }
}
