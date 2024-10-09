using System;
using System.Collections.Generic;
using System.Text;

namespace MediaBazaar.Logic_Layer
{
    public class KeySystem
    {
        private int id;
        private string key;
        private string used_by;

        public int ID { get { return id; } }
        public string Key { get { return key; } set { key = value; } }
        public string Used_By { get { return used_by; } set { used_by = value; } }
        public KeySystem(int Id,string Key,string Used_by)
        {
            id= Id;
            key = Key;
            used_by = Used_by;

        }
        public KeySystem(string Key)
        {
            key = Key;
        }
    }
}
