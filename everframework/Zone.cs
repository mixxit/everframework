using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everframework
{
    public class Zone
    {
        private string _name;
        private World _world;
        private List<ActiveMob> _activemobs = new List<ActiveMob>();
        private List<SpawnGroup> _spawngroups;

        public Zone(World world, string name, List<SpawnGroup> spawngroups)
        {
            this._world = world;
            this._name = name;
            this._spawngroups = spawngroups;
        }

        public void SpawnMob(Mob mob, Location location)
        {
            ActiveMob activemob = new ActiveMob(mob, location.GetZone());
            _activemobs.Add(activemob);
            activemob.Teleport(location);
        }

        public ActiveMob GetMobByGUID(Guid guid)
        {
            return _activemobs.Where(n => n.GetGuid().Equals(guid)).First();
        }

        public World GetWorld()
        {
            return this._world;
        }

        public string GetName()
        {
            return this._name;
        }
    }
}
