using AdaptiveTileExtensions.Support;
using System;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Markup;

namespace AdaptiveTileExtensions
{
    [ContentProperty( Name = "Children" )]
    [DataContract( Namespace = Defaults.Namespace )]
    public class SubGroup : Group
    {
        // private readonly List<Item> _items = new List<Item>();

        /// <summary>
        /// Gets or sets the width.
        /// NOTE: An 8px margin gets added between columns
        /// </summary>
        [DataMember( EmitDefaultValue = false )]
        public object Width
        {
            get { return width; }
            set { width = value.Convert<int?>(); }
        }	int? width;
        
        [DataMember( EmitDefaultValue = false )]
        public object TextStacking
        {
            get { return textStacking; }
            set { textStacking = value.Convert<TextStacking?>(); }
        }	TextStacking? textStacking;

        protected override Type[] AllowedTypes => new[] { typeof(Text), typeof(TileImage) };
    }
}