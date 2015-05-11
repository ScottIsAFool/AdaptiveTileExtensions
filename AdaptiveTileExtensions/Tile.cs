using System.Collections.Generic;
using System.Text;

namespace AdaptiveTileExtensions
{
    public class Tile
    {
        private const string Xml = "<tile version=\"{0}\"><visual>{1}</visual></tile>";

        internal Tile(string version)
        {
            Version = version;
            Tiles = new List<TileBinding>();
        }

        public string Version { get; set; }

        public List<TileBinding> Tiles { get; set; }

        public string GetXml()
        {
            var sb = new StringBuilder();
            foreach (var tile in Tiles)
            {
                sb.Append(tile.GetXml());
            }

            var xml = string.Format(Xml, Version, sb);
            return xml;
        }
    }
}