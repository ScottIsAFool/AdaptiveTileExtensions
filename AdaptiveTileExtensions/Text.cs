using System.Text;

namespace AdaptiveTileExtensions
{
    public class Text : Item
    {
        public string Content { get; set; }
        public TextStyle? Style { get; set; }
        public Alignment? Alignment { get; set; }
        public bool? WrapText { get; set; }
        public int? MaxLines { get; set; }
        
        /// <summary>
        /// Gets or sets whether the subtle style is applied.
        /// This results in a 60% opacity of text
        /// </summary>
        public bool? IsSubtleStyle { get; set; }

        /// <summary>
        /// Gets or sets the is numeral.
        /// This results in a reduction of line height so that content above and below come extremely close to the text
        /// This is only if the TextStyle is Title, SubHeader or Header
        /// </summary>
        public bool? IsNumeralStyle { get; set; }

        public Text()
        {
        }

        public Text(string content)
        {
            Content = content;
        }

        internal override string GetXml()
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
        }
    }
}