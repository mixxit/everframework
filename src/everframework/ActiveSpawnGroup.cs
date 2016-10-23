using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace everframework
{
    public class ActiveSpawnGroup
    {
        private Guid _guid = Guid.NewGuid();
        private SpawnGroup _spawngroup;
        private Zone _zone;

        public ActiveSpawnGroup(SpawnGroup spawngroup, Zone zone)
        {
            this._spawngroup = spawngroup;
            this._zone = zone;
        }

        public SpawnGroup GetSpawnGroup()
        {
            return this._spawngroup;
        }

        public ActiveMob GetActiveMob()
        {
            return GetZone().GetActiveMobForSpawnGroup(this);
        }

        internal void OnTick()
        {
            if (GetActiveMob() == null && _spawngroup.GetMobs().Count > 0)
            {
                Mob randommob = _spawngroup.GetMobs().OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                if (randommob == null)
                    return;

                Location location = new Location(GetZone(), _spawngroup.GetX(), _spawngroup.GetY(), _spawngroup.GetZ());
                GetZone().SpawnMobForSpawnGroup(randommob, this, location);
            }
        }

        internal Zone GetZone()
        {
            return this._zone;
        }
    }
}
