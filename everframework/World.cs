using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everframework
{
    public class World
    {
        public string name;
        private List<NPC> npcs = new List<NPC>();

        public World(String name)
        {
            this.name = name;
        }

        public void SpawnNPC(NPC npc, Location location)
        {
            npcs.Add(npc);
            npc.Teleport(location);
            
        }
    }
}
