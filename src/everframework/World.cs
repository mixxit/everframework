using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;

namespace everframework
{
    [XmlRoot("World")]
    public class World
    {
        private ILogger _logger;
        private string _name;
        private List<Zone> _zones = new List<Zone>();

        public World(string name)
        {
            this._name = name;
        }

        public String GetName()
        {
            return this._name;
        }

        public ILogger GetLogger()
        {
            return this._logger;
        }

        public void SetLogger(ILogger logger)
        {
            this._logger = logger;
        }

        public void AddZone(Zone zone)
        {
            _zones.Add(zone);
        }

        internal Zone GetZoneByName(string name)
        {
            return _zones.Where(z => z.GetName().Equals(name)).FirstOrDefault();
        }
    }
}
