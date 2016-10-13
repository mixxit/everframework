using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace everframework
{
    public class Zone
    {
        private string _name;
        private World _world;
        private List<ActiveMob> _activemobs = new List<ActiveMob>();
        private List<ActiveSpawnGroup> _activespawngroups = new List<ActiveSpawnGroup>();
        private List<SpawnGroup> _spawngroups;
        private Timer _timer = new Timer();

        public Zone(World world, string name, List<SpawnGroup> spawngroups)
        {
            this._world = world;
            this._name = name;
            this._spawngroups = spawngroups;

            this._timer.Elapsed += new ElapsedEventHandler(OnTick);
            this._timer.Interval = 5000;
            this._timer.Enabled = true;
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            TickSpawnGroups();
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
            ActiveMob activemob = new ActiveMob(mob, location.GetZone());
            _activemobs.Add(activemob);
            activemob.Teleport(location);
        }

        public ActiveMob GetActiveMobForSpawnGroup(ActiveSpawnGroup spawngroup)
        {
            foreach(ActiveMob activemob in _activemobs)
            {
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
