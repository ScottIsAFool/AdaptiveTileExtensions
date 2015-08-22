using AdaptiveTileExtensions.Support;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Markup;

namespace AdaptiveTileExtensions
{
    [ContentProperty( Name = "Items" )]
    [DataContract( Namespace = Defaults.Namespace )]
    public class TileBinding
    {
        [DataMember]
        public TemplateType TemplateType { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public object Branding // Have to make object to keep UWP Xaml happy.  Very, very disappointing.
        {
            get { return branding; }
            set { branding = value.Convert<Branding?>(); }
        }	Branding? branding;
        
        [DataMember( EmitDefaultValue = false )]
        public string DisplayName { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public object TextStacking // Have to make object to keep UWP Xaml happy.  Very, very disappointing.
        {
            get { return textStacking; }
            set { textStacking = value.Convert<TextStacking?>(); }
        }	TextStacking? textStacking;
        
        [DataMember( EmitDefaultValue = false )]
        public object OverlayOpacity // Have to make object to keep UWP Xaml happy.  Very, very disappointing.
        {
            get { return overlayOpacity; }
            set { overlayOpacity = value.Convert<int?>(); }
        }	int? overlayOpacity;

        [DataMember]
        public ItemCollection Items { get; set; } = new ItemCollection( typeof(TileImage), typeof(Group) );
    }
}