using System.Text;

namespace AdaptiveTileExtensions
{
    public class TileImage : Item
    {
        public TileImage(ImagePlacement placement)
        {
            Placement = placement;
        }

        public ImagePlacement Placement { get; set; }
        public string Source { get; set; }
        public bool? RemoveMargin { get; set; }
        public Alignment? ImageAlignment { get; set; }
        public ImageCropping? ImageCropping { get; set; }

        internal override string GetXml()
        {
            var sb = new StringBuilder($"<image placement=\"{Placement}\"");

            var source = $" src=\"{Source}\"";
            sb.Append(source);

            if (RemoveMargin.HasValue)
            {
                var margin = $" hint-removeMargin=\"{RemoveMargin.Value}\"";
                sb.Append(margin);
            }

            if (ImageAlignment.HasValue)
            {
                var alignment = $" hint-align=\"{ImageAlignment.Value}\"";
                sb.Append(alignment);
            }

            if (ImageCropping.HasValue)
            {
                var cropping = $" hint-crop=\"{ImageCropping.Value}\"";
                sb.Append(cropping);
            }

            sb.Append("/>");
            return sb.ToString();
        }
    }
}