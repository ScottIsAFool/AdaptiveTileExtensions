using System.Runtime.Serialization;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensions
{
    [DataContract( Namespace = Defaults.Namespace )]
    public enum ImagePlacement
    {
        [EnumMember]Inline,
        [EnumMember]Background,
        [EnumMember]Peek
    }
}