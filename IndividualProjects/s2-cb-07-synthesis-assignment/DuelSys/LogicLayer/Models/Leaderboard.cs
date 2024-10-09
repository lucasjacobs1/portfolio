using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class Leaderboard
    {
        private User user;
        private int wincounter;

        #region Properties
        public User User { get { return user; } set { user = value; } }
        public int Wincounter { get { return wincounter; } set { wincounter = value; } }
        #endregion
        public Leaderboard(User user, int wincounter)
        {
            this.user = user;
            this.wincounter = wincounter;
        }
    }
}
