using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everframework
{
    public class Zone
    {
        string name;
        World world;

        public Zone(World world, string name)
        {
            this.world = world;
            this.name = name;
        }

        public World GetWorld()
        {
            return this.world;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
