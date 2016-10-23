using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace everframework
{
    public class SpawnGroup
    {
        private List<Mob> _mobs = new List<Mob>();
        private decimal _x;
        private decimal _y;
        private decimal _z;
        private string _worldname;

        public SpawnGroup(String worldname, Decimal x, Decimal y, Decimal z)
        {
            this._worldname = worldname;
            this._x = x;
            this._y = y;
            this._z = z;
        }

        internal decimal GetX()
        {
            return _x;
        }

        internal decimal GetY()
        {
            return _y;
        }

        internal decimal GetZ()
        {
            return _z;
        }

        internal string GetWorldName()
        {
            return _worldname;
        }

        internal List<Mob> GetMobs()
        {
            return this._mobs;
        }

        public void AddMob(Mob mob)
        {
            this._mobs.Add(mob);
        }
    }
}
