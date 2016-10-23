using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace everframework
{
    public class Location
    {
        private decimal x;
        private decimal y;
        private decimal z;
        private Zone zone;

        public Location(Zone zone, decimal x, decimal y, decimal z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.zone = zone;
        }

        internal decimal GetX()
        {
            return this.x;
        }

        internal decimal GetY()
        {
            return this.y;
        }

        internal decimal GetZ()
        {
            return this.z;
        }

        internal World GetWorld()
        {
            return this.zone.GetWorld();
        }

        internal Zone GetZone()
        {
            return this.zone;
        }
    }
}
