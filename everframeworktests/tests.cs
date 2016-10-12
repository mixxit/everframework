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

            Zone zone = new Zone(world, "TestZone", spawngroups);
        }
    }
}
