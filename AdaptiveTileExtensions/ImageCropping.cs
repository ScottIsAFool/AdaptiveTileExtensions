using System.Runtime.Serialization;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensions
{
    [DataContract( Namespace = Defaults.Namespace )]
    public enum ImageCropping
    {
        [EnumMember]None,
        [EnumMember]Circle
    }
}