using AdaptiveTileExtensions.Support;
using System.Runtime.Serialization;

namespace AdaptiveTileExtensions.Testing
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
