using Windows.Data.Xml.Xsl;
using Windows.UI.Notifications;

namespace AdaptiveTileExtensions.Support
{
    class TileNotificationFactory : ITileNotificationFactory
    {
        public static TileNotificationFactory Instance { get; } = new TileNotificationFactory();

        readonly IObjectDocumentConverter converter;
        readonly XsltProcessor processor;

        public TileNotificationFactory() : this( ObjectDocumentConverter.Instance )
        {}

        public TileNotificationFactory( IObjectDocumentConverter converter ) : this( converter, Defaults.Processor )
        {}

        public TileNotificationFactory( IObjectDocumentConverter converter, XsltProcessor processor )
        {
            this.converter = converter;
            this.processor = processor;
        }

        public TileNotification Create( Tile tile )
        {
            var document = converter.Convert( tile );
            var transformed = processor.TransformToDocument( document );
            
            var result = new TileNotification( transformed );
            return result;
        }
    }
}