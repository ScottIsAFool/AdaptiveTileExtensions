using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Markup;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensions
{
	[ContentProperty( Name = "Bindings" )]
    [DataContract( Namespace = Defaults.Namespace )]
	public class Tile
    {
        [DataMember]
        public Collection<TileBinding> Bindings { get; set; } = new Collection<TileBinding>();

        [DataMember]
        public string Version { get; set; } = "3";

        /*private const string Xml = "<tile version=\"{0}\"><visual>{1}</visual></tile>";
        }*/
    }
}