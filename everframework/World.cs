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
        private List<Zone> zones = new List<Zone>();

        public World(string name)
        {
            this.name = name;
        }

        public void AddZone(Zone zone)
        {
            zones.Add(zone);
        }

        public Zone GetZoneByName(string name)
        {
            return zones.Where(z => z.GetName().Equals(name)).First();
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
