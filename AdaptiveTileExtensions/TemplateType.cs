using System.Runtime.Serialization;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensions
{
    [DataContract( Namespace = Defaults.Namespace )]
    public enum TemplateType
    {
        [EnumMember]TileSmall,
        [EnumMember]TileMedium,
        [EnumMember]TileWide,
        
        /// <summary>
        /// The large tile size
        /// NOTE: This is for desktop only.
        /// </summary>
        [EnumMember]TileLarge
    }
}