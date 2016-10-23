using everframework;
using System;
using System.Collections.Generic;
using Xunit;

namespace everframeworktests
{
    public class tests
    {
        [Fact]
        public void BootZone()
        {
            World world = new World("TestWorld");
            Zone zone = new Zone(world, "TestZone", new List<SpawnGroup>());
        }

        [Fact]
        public void SpawnNPC()
        {
            World world = new World("TestWorld");
            Zone zone = new Zone(world, "TestZone", new List<SpawnGroup>());
            world.AddZone(zone);

            Mob mob = new Mob("TestMob");
            zone.SpawnMob(mob, new Location(zone, 0, 0, 0));
        }

        [Fact]
        public void InitialiseSpawnGroups()
        {
            World world = new World("TestWorld");
            List<SpawnGroup> spawngroups = new List<SpawnGroup>();
            SpawnGroup spawngroup = new SpawnGroup("TestWorld", 0, 0, 0);
            spawngroup.AddMob(new Mob("TestMob"));
            spawngroups.Add(spawngroup);
            Zone zone = new Zone(world, "TestZone", spawngroups);
            zone.TickSpawnGroups();

            int count = zone.GetActiveMobs().Count;
            Assert.Equal(1, count);
        }

        [Fact]
        public void DespawnSpawnGroup()
        {
            World world = new World("TestWorld");
            List<SpawnGroup> spawngroups = new List<SpawnGroup>();
            SpawnGroup spawngroup = new SpawnGroup("TestWorld", 0, 0, 0);
            spawngroup.AddMob(new Mob("TestMob"));
            spawngroups.Add(spawngroup);
            Zone zone = new Zone(world, "TestZone", spawngroups);
            zone.TickSpawnGroups();
            ActiveSpawnGroup asg = zone.GetActiveSpawnGroupFromSpawnGroup(spawngroup);
            if (asg == null)
                throw new Exception("Could not locate active spawn group from spawngroup");
            if (asg.GetActiveMob() == null)
                throw new Exception("Could not find active mob");


            ActiveMob am = zone.GetActiveMobForSpawnGroup(asg);
            am.Despawn();

            int count = zone.GetActiveMobs().Count;
            Assert.Equal(0, count);
        }
    }
}
