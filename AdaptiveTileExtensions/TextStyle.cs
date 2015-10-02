using System;
using System.Runtime.Serialization;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensions
{
    [DataContract( Namespace = Defaults.Namespace )]
    public enum TextStyle
    {
        /// <summary>
        /// The caption style
        /// Font Height: 12epx
        /// Font Weight: Regular
        /// </summary>
        [EnumMember]Caption,

        /// <summary>
        /// The base style
        /// Font Height: 15epx
        /// Font Weight: SemiBold
        /// </summary>
        [EnumMember]Base,

        /// <summary>
        /// The body style
        /// Font Height: 15epx
        /// Font Weight: Regular
        /// </summary>
        [EnumMember]Body,

        /// <summary>
        /// The caption subtle style
        /// Obsolete: Please use Caption, then set IsCaptionStyle = true
        /// </summary>
        [Obsolete("Please use Caption, then set IsCaptionStyle = true")]
        [EnumMember]CaptionSubtle,

        /// <summary>
        /// The subtitle style
        /// Font Height: 20epx
        /// Font Weight: Regular
        /// </summary>
        [EnumMember]Subtitle,

        /// <summary>
        /// The title style
        /// Font Height: 24epx
        /// Font Weight: SemiLight
        /// </summary>
        [EnumMember]Title,

        /// <summary>
        /// The subheader style
        /// Font Height: 34epx
        /// Font Weight: Light
        /// </summary>
        [EnumMember]Subheader,

        /// <summary>
        /// The header style
        /// Font Height: 46epx
        /// Font Weight: Light
        /// </summary>
        [EnumMember]Header
    }
}