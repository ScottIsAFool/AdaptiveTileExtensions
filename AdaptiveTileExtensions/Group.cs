using System.Collections.Generic;
using System.Text;

namespace AdaptiveTileExtensions
{
    internal class Group : Item
    {
        internal Group()
        {
            SubGroups = new List<SubGroup>();
        }

        internal List<SubGroup> SubGroups { get; set; }
        internal override string GetXml()
        {
            var sb = new StringBuilder("<group>");

            foreach (var subgroup in SubGroups)
            {
                sb.Append(subgroup.GetXml());
            }

            sb.Append("</group>");

            return sb.ToString();
        }
    }
}