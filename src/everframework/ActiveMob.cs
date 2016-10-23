using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace everframework
{
    public class ActiveMob
    {
        Mob _mob;
        Guid _guid = Guid.NewGuid();
        Location _location;
        Zone _zone;
        ActiveSpawnGroup _activespawngroup;

        public ActiveMob(Mob mob, Zone zone)
        {
            this._mob = mob;
            this._zone = zone;
        }

        internal ActiveMob(Mob mob, Zone zone, ActiveSpawnGroup activespanwgroup)
        {
            this._mob = mob;
            this._zone = zone;
            this._activespawngroup = activespanwgroup;
        }

        internal ActiveSpawnGroup GetActiveSpawnGroup()
        {
            return this._activespawngroup;
        }

        public void Despawn()
        {
            _zone.DespawnActiveMob(this);
        }

        internal Guid GetGuid()
        {
            return this._guid;
        }

        internal void Teleport(Location location)
        {
            if (location.GetWorld() != _zone.GetWorld())
                throw new InvalidTeleportTargetException("ActiveMob cannot teleport between zones");
            _location = location;
        }
    }
}
