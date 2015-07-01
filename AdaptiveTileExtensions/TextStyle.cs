using System;

namespace AdaptiveTileExtensions
{
    public enum TextStyle
    {
        /// <summary>
        /// The caption style
        /// Font Height: 12epx
        /// Font Weight: Regular
        /// </summary>
        Caption,

        /// <summary>
        /// The base style
        /// Font Height: 15epx
        /// Font Weight: SemiBold
        /// </summary>
        Base,

        /// <summary>
        /// The body style
        /// Font Height: 15epx
        /// Font Weight: Regular
        /// </summary>
        Body,

        /// <summary>
        /// The caption subtle style
        /// Obsolete: Please use Caption, then set IsCaptionStyle = true
        /// </summary>
        [Obsolete("Please use Caption, then set IsCaptionStyle = true")]
        CaptionSubtle,

        /// <summary>
        /// The subtitle style
        /// Font Height: 20epx
        /// Font Weight: Regular
        /// </summary>
        Subtitle,

        /// <summary>
        /// The title style
        /// Font Height: 24epx
        /// Font Weight: SemiLight
        /// </summary>
        Title,

        /// <summary>
        /// The subheader style
        /// Font Height: 34epx
        /// Font Weight: Light
        /// </summary>
        Subheader,

        /// <summary>
        /// The header style
        /// Font Height: 46epx
        /// Font Weight: Light
        /// </summary>
        Header
    }
}