using System.Runtime.Serialization;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensions
{
    [DataContract( Namespace = Defaults.Namespace )]
    public enum Branding
    {
        [EnumMember]Name,
        [EnumMember]None,
        [EnumMember]Logo,
        [EnumMember]NameAndLogo
    }
}