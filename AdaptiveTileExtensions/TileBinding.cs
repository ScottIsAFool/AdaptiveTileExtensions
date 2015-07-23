using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveTileExtensions
{
    public class TileBinding
    {
        private readonly List<Item> _items = new List<Item>();
        private Group _group = new Group();

        internal TileBinding()
        {
        }

        public static TileBinding Create(TemplateType templateType)
        {
            return new TileBinding { TemplateType = templateType };
        }

        public TemplateType TemplateType { get; set; }

        public Branding? Branding { get; set; }

        public string DisplayName { get; set; }

        public TextStacking? TextStacking { get; set; }

        public int? OverlayOpacity { get; set; }

        public void Add(Item item)
        {
            var subGroup = item as SubGroup;
            if (subGroup != null)
            {
                AddSubgroup(subGroup);
            }
            else
            {
                _items.Add(item);
            }
        }

        /// <summary>
        /// Adds the subgroup.
        /// </summary>
        /// <param name="subGroup">The sub group.</param>
        /// <param name="addToNewGroup">if set to <c>true</c> [add to new group]. Once a new group has been added, no more subgroups can be added to any previous groups</param>
        public void AddSubgroup(SubGroup subGroup, bool addToNewGroup = false)
        {
            if (subGroup != null)
            {
                if (addToNewGroup)
                {
                    _group = new Group();
                }

                _group.SubGroups.Add(subGroup);

                var groupAdded = _items.LastOrDefault(x => x is Group);
                if (groupAdded == null || addToNewGroup)
                {
                    _items.Add(_group);
                }
            }
        }

        public void ClearItems()
        {
            _items.Clear();
        }

        internal string GetXml()
        {
            var sb = new StringBuilder($"<binding template=\"{TemplateType}\"");

            if (!string.IsNullOrEmpty(DisplayName))
            {
                var displayName = $" displayName=\"{DisplayName}\"";
                sb.Append(displayName);
            }

            if (Branding.HasValue)
            {
                var branding = $" branding=\"{Branding.Value}\"";
                sb.Append(branding);
            }

            if (TextStacking.HasValue)
            {
                var textStacking = $" hint-textStacking=\"{TextStacking.Value}\"";
                sb.Append(textStacking);
            }

            if (OverlayOpacity.HasValue)
            {
                var overlay = $" hint-overlay=\"{OverlayOpacity.Value}\"";
                sb.Append(overlay);
            }

            sb.Append(">");
            foreach (var item in _items)
            {
                sb.Append(item.GetXml());
            }

            sb.Append("</binding>");
            return sb.ToString();
        }
    }
}