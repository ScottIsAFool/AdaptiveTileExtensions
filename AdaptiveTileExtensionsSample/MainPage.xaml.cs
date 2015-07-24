using Windows.UI.Notifications;
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
            
            #region for wide tile with background 
            
            var wideBinding = TileBinding.Create(TemplateType.TileWide);
            wideBinding.Branding = Branding.NameAndLogo;
            var wideLogo = new TileImage(ImagePlacement.Background)
            {
                Source = "http://fc02.deviantart.net/fs71/i/2013/359/a/4/deadpool_logo_1_fill_by_mr_droy-d5q6y5u.png"
            };
            //background/peek images need to be at the root of the binding;
            wideBinding.BackgroundImage = wideLogo;

            var wideHeader = new Text("You have mail") {Style = TextStyle.Body};
            var wideContent = new Text("Someone likes you!") {Style = TextStyle.Caption};

            var wideSubgroup = new SubGroup();
            wideSubgroup.AddText(wideHeader);
            wideSubgroup.AddText(wideContent);
            
            wideBinding.AddSubgroup(wideSubgroup, true);

            #endregion

            #region square tile 
           
            var binding = TileBinding.Create(TemplateType.TileMedium);
            binding.Branding = Branding.None;

            var header = new Text("You have mail") { Style = TextStyle.Body, WrapText = true };
            var content = new Text("Someone likes you!") { Style = TextStyle.Caption, IsSubtleStyle = true , WrapText = true,Alignment = Alignment.Center};
            var logo = new TileImage(ImagePlacement.Inline)
            {
                Source = "http://fc02.deviantart.net/fs71/i/2013/359/a/4/deadpool_logo_1_fill_by_mr_droy-d5q6y5u.png"
            };

            var imageSubgroup = new SubGroup()
            {
                Width = 20
            };
            imageSubgroup.AddImage(logo);


            var subgroup = new SubGroup();
            subgroup.AddText(header);
            subgroup.AddText(content);
          
            binding.AddSubgroup(imageSubgroup);
            binding.AddSubgroup(subgroup);
            
            #endregion

            // Add the types of tile bindings to the tile.
            tile.Tiles.Add(wideBinding);
            tile.Tiles.Add(binding); 

            var notification = tile.GetNotification();

            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
            
        }
    }
}
