using System.Runtime.Serialization;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensions
{
    [DataContract( Namespace = Defaults.Namespace )]
    public enum TextStacking
    {
        [EnumMember]Top,
        [EnumMember]Center,
        [EnumMember]Bottom
    }
}