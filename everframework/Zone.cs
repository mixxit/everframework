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
        List<NPC> npcs = new List<NPC>();

        public Zone(World world, string name)
        {
            this.world = world;
            this.name = name;
        }

        public void SpawnNPC(NPC npc, Location location)
        {
            npcs.Add(npc);
            npc.Teleport(location);
        }

        public NPC GetNPCByGUID(Guid guid)
        {
            return npcs.Where(n => n.GetGuid().Equals(guid)).First();
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
