using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace everframework
{
    public class Zone
    {
        private string _name;
        private World _world;
        private List<ActiveMob> _activemobs = new List<ActiveMob>();
        private List<ActiveSpawnGroup> _activespawngroups = new List<ActiveSpawnGroup>();
        private List<SpawnGroup> _spawngroups;
        private Timer _timer;

        public Zone(World world, string name, List<SpawnGroup> spawngroups)
        {
            this._world = world;
            this._name = name;
            this._spawngroups = spawngroups;

            this._timer = new Timer(OnTick, this, 5000, Timeout.Infinite);
        }

        public void DespawnActiveMob(ActiveMob activemob)
        {
            if (activemob.GetActiveSpawnGroup() != null)
                _activespawngroups.Remove(activemob.GetActiveSpawnGroup());

            _activemobs.Remove(activemob);
        }

        public static void OnTick(Object o)
        {
            if (o.GetType() == typeof(Zone))
            {
                Zone zone = (Zone)o;
                zone.TickSpawnGroups();
            }
        }

        public void TickSpawnGroups()
        {
            foreach (SpawnGroup spawngroup in _spawngroups)
            {
                ActiveSpawnGroup activegroup = _activespawngroups.Where(asg => asg.GetSpawnGroup().Equals(spawngroup)).FirstOrDefault();
                if (activegroup == null)
                {
                    activegroup = new ActiveSpawnGroup(spawngroup, this);
                    _activespawngroups.Add(activegroup);
                }

                activegroup.OnTick();
            }
        }

        internal void SpawnMobForSpawnGroup(Mob mob, ActiveSpawnGroup activespawngroup, Location location)
        {
            ActiveMob activemob = new ActiveMob(mob, location.GetZone(), activespawngroup);
            _activemobs.Add(activemob);
            activemob.Teleport(location);
        }

        public ActiveSpawnGroup GetActiveSpawnGroupFromSpawnGroup(SpawnGroup spawngroup)
        {
            return _activespawngroups.Where(asg => asg.GetSpawnGroup().Equals(spawngroup)).FirstOrDefault();
        }

        public ActiveMob GetActiveMobForSpawnGroup(ActiveSpawnGroup spawngroup)
        {
            foreach (ActiveMob activemob in _activemobs)
            {
                if (activemob.GetActiveSpawnGroup() == null)
                    return null;

                if (activemob.GetActiveSpawnGroup().Equals(spawngroup))
                    return activemob;
            }

            return null;
        }

        public List<ActiveMob> GetActiveMobs()
        {
            return _activemobs;
        }

        public void SpawnMob(Mob mob, Location location)
        {
            ActiveMob activemob = new ActiveMob(mob, location.GetZone());
            _activemobs.Add(activemob);
            activemob.Teleport(location);
        }

        internal ActiveMob GetMobByGUID(Guid guid)
        {
            return _activemobs.Where(n => n.GetGuid().Equals(guid)).FirstOrDefault();
        }

        internal World GetWorld()
        {
            return this._world;
        }

        internal string GetName()
        {
            return this._name;
        }
    }
}
