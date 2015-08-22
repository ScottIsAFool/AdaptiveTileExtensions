using System.Runtime.Serialization;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensionsSample
{
	[DataContract( Namespace = Defaults.Namespace )]
	public sealed partial class Tile
	{
		public Tile()
		{
			InitializeComponent();
		}
	}
}
