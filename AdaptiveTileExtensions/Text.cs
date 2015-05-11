using System.Text;

namespace AdaptiveTileExtensions
{
    public class Text : Item
    {
        public string Content { get; set; }
        public TextStyle? Style { get; set; }
        public TextAlignment? TextAlignment { get; set; }
        public bool? WrapText { get; set; }
        public int? MaxLines { get; set; }

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
                var style = $" hint-style=\"{Style.Value}\"";
                sb.Append(style);
            }

            if (TextAlignment.HasValue)
            {
                var alignment = $" hint-align=\"{TextAlignment.Value}\"";
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