using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using AdaptiveTileExtensions;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AdaptiveTileExtensionsSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var tile = AdaptiveTile.CreateTile();
            var binding = TileBinding.Create(TemplateType.TileWide);
            binding.Branding = Branding.None;

            var header = new Text("You have mail") {Style = TextStyle.Body};
            var content = new Text("Someone likes you!") {Style = TextStyle.Caption};
            var logo = new TileImage(ImagePlacement.Inline)
            {
                Source = "http://fc02.deviantart.net/fs71/i/2013/359/a/4/deadpool_logo_1_fill_by_mr_droy-d5q6y5u.png"
            };

            var logoSubGroup = new SubGroup {Width = 40};
            logoSubGroup.AddImage(logo);

            var subgroup = new SubGroup();
            subgroup.AddText(header);
            subgroup.AddText(content);

            binding.AddSubgroup(logoSubGroup);
            binding.AddSubgroup(subgroup, true);

            tile.Tiles.Add(binding);
            var xml = tile.GetXml();


            if (string.IsNullOrEmpty(xml))
            {
                
            }
        }
    }
}
