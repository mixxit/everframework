using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everframework
{
    public class World
    {
        private string name;

        public World(String name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
