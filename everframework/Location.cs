using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public decimal GetX()
        {
            return this.x;
        }

        public decimal GetY()
        {
            return this.y;
        }

        public decimal GetZ()
        {
            return this.z;
        }

        public World GetWorld()
        {
            return this.zone.GetWorld();
        }

        public Zone GetZone()
        {
            return this.zone;
        }
    }
}
