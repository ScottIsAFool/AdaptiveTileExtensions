using AdaptiveTileExtensions.Support;
using System.Runtime.Serialization;

namespace AdaptiveTileExtensions
{
    [DataContract( Namespace = Defaults.Namespace )]
    public class TileImage : Item
    {
        [DataMember]
        public ImagePlacement Placement { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public object RemoveMargin // Have to make object to keep UWP Xaml happy.  Very, very disappointing.
        {
            get { return removeMargin; }
            set { removeMargin = value.Convert<bool?>(); }
        }	bool? removeMargin;

        [DataMember( EmitDefaultValue = false )]
        public object ImageAlignment // Have to make object to keep UWP Xaml happy.  Very, very disappointing.
        {
            get { return imageAlignment; }
            set { imageAlignment = value.Convert<Alignment?>(); }
        }	Alignment? imageAlignment;

        [DataMember( EmitDefaultValue = false )]
        public object ImageCropping // Have to make object to keep UWP Xaml happy.  Very, very disappointing.
        {
            get { return imageCropping; }
            set { imageCropping = value.Convert<ImageCropping?>(); }
        }	ImageCropping? imageCropping;
    }
}