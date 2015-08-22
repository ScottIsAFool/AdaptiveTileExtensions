using System.Runtime.Serialization;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensions
{
    [DataContract( Namespace = Defaults.Namespace )]
    public enum Alignment
    {
        [EnumMember]Left,
        [EnumMember]Center,
        [EnumMember]Right,
        [EnumMember]Stretch
    }
}