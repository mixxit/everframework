using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using everframework;
using System.Collections.Generic;

namespace everframeworktests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void BootZone()
        {
            World world = new World("TestWorld");
            Zone zone = new Zone(world, "TestZone", new List<SpawnGroup>());
        }

        [TestMethod]
        public void SpawnNPC()
        {
            World world = new World("TestWorld");
            Zone zone = new Zone(world, "TestZone", new List<SpawnGroup>());
            world.AddZone(zone);

            Mob mob = new Mob("TestMob");
            zone.SpawnMob(mob, new Location(zone, 0,0,0));
        }

        [TestMethod]
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
            Assert.AreEqual(1, count);
        }

        [TestMethod]
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
            Assert.AreEqual(0, count);
        }
    }
}
