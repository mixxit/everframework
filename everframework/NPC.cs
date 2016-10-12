using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everframework
{
    public class NPC
    {
        private Guid guid = new Guid();

        private Location location;
        public void Teleport(Location location)
        {
            this.location = location;
        }

        public Guid GetGuid()
        {
            return this.guid;
        }

        public Location GetLocation()
        {
            return this.location;
        }

        private List<NPC> npcs = new List<NPC>();
    }
}
