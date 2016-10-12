using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using everframework;

namespace everframeworktests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void BootZone()
        {
            World world = new World("TestWorld");
            Zone zone = new Zone(world, "TestZone");
        }

        [TestMethod]
        public void SpawnNPC()
        {
            World world = new World("TestWorld");
            Zone zone = new Zone(world, "TestZone");
            NPC npc = new NPC();
            zone.SpawnNPC(npc, new Location(zone, 0,0,0));
        }

        [TestMethod]
        public void InitialiseSpawnGroup()
        {

        }
    }
}
