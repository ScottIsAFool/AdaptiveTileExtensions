using System.Collections.Generic;
using System.Text;

namespace AdaptiveTileExtensions
{
    public class SubGroup : Item
    {
        private readonly List<Item> _items = new List<Item>();

        /// <summary>
        /// Gets or sets the width.
        /// NOTE: An 8px margin gets added between columns
        /// </summary>
        public int? Width { get; set; }

        public TextStacking? TextStacking { get; set; }

        public void AddText(Text text)
        {
            _items.Add(text);
        }

        public void AddImage(TileImage tileImage)
        {
            _items.Add(tileImage);
        }

        public void ClearItems()
        {
            _items.Clear();
        }

        internal override string GetXml()
        {
            var sb = new StringBuilder("<subgroup");

            if (Width.HasValue)
            {
                var width = $" hint-weight=\"{Width.Value}\"";
                sb.Append(width);
            }

            if (TextStacking.HasValue)
            {
                var textStacking = $" hint-textStacking=\"{TextStacking.Value}\"";
                sb.Append(textStacking);
            }

            sb.Append(">");

            foreach (var item in _items)
            {
                sb.Append(item.GetXml());
            }

            sb.Append("</subgroup>");
            return sb.ToString();
        }
    }
}