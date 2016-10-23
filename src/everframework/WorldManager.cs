using everframework;
using System;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace everframework
{
    public sealed class WorldManager
    {
        private World _world;
        private ILogger _logger;

        public WorldManager(ILogger logger)
        {
            this._logger = logger;
        }

        public void LoadDefaultWorld()
        {
            GenerateBasicWorldFile();
            LoadWorld();
        }

        public void GenerateBasicWorldFile()
        {
            WorldSave worldsave = WorldSave.Default();
            SaveWorld(worldsave);
        }

        public void SaveWorld(WorldSave worldsave)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(WorldSave));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, worldsave);
                File.WriteAllText("world.xml", writer.ToString());
                this.GetLogger().LogInformation("Saved world.xml");
            }
        }
        
        public ILogger GetLogger()
        {
            return this._logger;
        }

        public void LoadWorld()
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(WorldSave));
            using (StringReader reader = new StringReader(File.ReadAllText("world.xml")))
            {
                WorldSave worldsave = (WorldSave)serializer.Deserialize(reader);

                World world = new World(worldsave.name);
                _world = world;
                _world.SetLogger(GetLogger());
                _world.GetLogger().LogInformation("Loaded World: " + _world.GetName());

                LoadZones(worldsave);
            }
        }

        public void LoadZones(WorldSave worldsave)
        {
            foreach (ZoneSave zonesave in worldsave.zones)
            {
                List<SpawnGroup> spawngroups = new List<SpawnGroup>();

                foreach(SpawnGroupSave spawngroupsave in zonesave.spawngroupsaves)
                {
                    SpawnGroup spawngroup = new SpawnGroup(worldsave.name, spawngroupsave.x, spawngroupsave.y, spawngroupsave.z);
                    foreach (MobSave mobsave in spawngroupsave.mobs)
                    {
                        spawngroup.AddMob(new Mob(mobsave.name));
                    }
                    spawngroups.Add(spawngroup);
                }

                Zone zone = new Zone(_world, zonesave.name, spawngroups);
                _world.AddZone(zone);
            }
        }
    }
}
