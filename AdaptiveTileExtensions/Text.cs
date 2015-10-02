using System.Runtime.Serialization;
using AdaptiveTileExtensions.Support;

namespace AdaptiveTileExtensions
{
    [DataContract( Namespace = Defaults.Namespace )]
    public class Text : Item
    {
        [DataMember]
        public string Content { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public object Style
        {
            get { return style; }
            set { style = value.Convert<TextStyle?>(); }
        }	TextStyle? style;
        
        [DataMember( EmitDefaultValue = false )]
        public object Alignment
        {
            get { return alignment; }
            set { alignment = value.Convert<Alignment?>(); }
        }	Alignment? alignment;

        [DataMember( EmitDefaultValue = false )]
        public object WrapText
        {
            get { return wrapText; }
            set { wrapText = value.Convert<bool?>(); }
        }	bool? wrapText;
        
        [DataMember( EmitDefaultValue = false )]
        public object MaxLines
        {
            get { return maxLines; }
            set { maxLines = value.Convert<int?>(); }
        }	int? maxLines;
        
        /// <summary>
        /// Gets or sets whether the subtle style is applied.
        /// This results in a 60% opacity of text
        /// </summary>
        [DataMember( EmitDefaultValue = false )]
        public object IsSubtleStyle
        {
            get { return isSubtleStyle; }
            set { isSubtleStyle = value.Convert<bool?>(); }
        }	bool? isSubtleStyle;
        
        /// <summary>
        /// Gets or sets the is numeral.
        /// This results in a reduction of line height so that content above and below come extremely close to the text
        /// This is only if the TextStyle is Title, SubHeader or Header
        /// </summary>
        [DataMember( EmitDefaultValue = false )]
        public object IsNumeralStyle
        {
            get { return isNumeralStyle; }
            set { isNumeralStyle = value.Convert<bool?>(); }
        }	bool? isNumeralStyle;

        /*internal override string GetXml()
        {
            var sb = new StringBuilder("<text");

            if (Style.HasValue)
            {
                var value = Style.Value.ToString().ToLowerInvariant();
                if (IsSubtleStyle.HasValue && IsSubtleStyle.Value)
                {
                    value += "Subtle";
                }
                else
                {
                    if (IsNumeralStyle.HasValue && IsNumeralStyle.Value)
                    {
                        value += "Numeral";
                    }
                }

                var style = $" hint-style=\"{value}\"";
                sb.Append(style);
            }

            if (Alignment.HasValue)
            {
                var alignment = $" hint-align=\"{Alignment.Value}\"";
                sb.Append(alignment);
            }

            if (WrapText.HasValue)
            {
                var wrapText = $" hint-wrap=\"{WrapText.Value}\"";
                sb.Append(wrapText);
            }

            if (MaxLines.HasValue)
            {
                var maxLines = $" hint-maxLines=\"{MaxLines.Value}\"";
                sb.Append(maxLines);
            }

            sb.Append($">{Content}</text>");
            return sb.ToString();
        }*/
    }
}