using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace everframework
{
    public class WorldSave
    {
        public string name;
        public List<ZoneSave> zones = new List<ZoneSave>();

        public static WorldSave Default()
        {
            WorldSave worldsave = new WorldSave();
            worldsave.name = "DefaultWorld";

            List<SpawnGroupSave> spawngroupsaves = new List<SpawnGroupSave>();
            SpawnGroupSave spawngroupsave = new SpawnGroupSave();
            spawngroupsave.x = 0;
            spawngroupsave.y = 0;
            spawngroupsave.z = 0;

            MobSave mobsave = new MobSave();
            mobsave.name = "TesterMob";

            spawngroupsave.mobs.Add(mobsave);

            spawngroupsaves.Add(spawngroupsave);
            
            ZoneSave zonesave = new ZoneSave();
            zonesave.name = "DefaultZone";
            zonesave.spawngroupsaves = spawngroupsaves;

            worldsave.zones.Add(zonesave);
            
            return worldsave;
        }
    }
}
