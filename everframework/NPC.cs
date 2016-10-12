using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everframework
{
    public class NPC
    {
        private Location location;
        public void Teleport(Location location)
        {
            this.location = location;
        }

        public Location GetLocation()
        {
            return this.location;
        }
    }
}
