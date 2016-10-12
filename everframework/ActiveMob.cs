using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everframework
{
    public class ActiveMob
    {
        Mob _mob;
        Guid _guid = Guid.NewGuid();
        Location _location;
        Zone _zone;

        public ActiveMob(Mob mob, Zone zone)
        {
            this._mob = mob;
            this._zone = zone;
        }

        public Guid GetGuid()
        {
            return this._guid;
        }

        public void Teleport(Location location)
        {
            if (location.GetWorld() != _zone.GetWorld())
                throw new InvalidTeleportTargetException("You cannot teleport between zones");
            _location = location;
        }
    }
}
