using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everframework
{
    public class Mob
    {
        public string _name;
        public Mob(String name)
        {
            this._name = name;
        }

        public string GetName()
        {
            return this._name;
        }
    }
}
