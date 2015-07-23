using System;
using System.Collections.Generic;
using System.Text;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

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

        [Obsolete("This will soon be removed, please use GetNotification()", true)]
        public string GetXml()
        {
            return string.Empty;
        }

        private string GetXmlInternal()
        {
            var sb = new StringBuilder();
            foreach (var tile in Tiles)
            {
                sb.Append(tile.GetXml());
            }

            var xml = string.Format(Xml, Version, sb);
            return xml;
        }

        public TileNotification GetNotification()
        {
            var doc = new XmlDocument();
            var xml = GetXmlInternal();
            doc.LoadXml(xml);

            return new TileNotification(doc);
        }
    }
}