using Windows.UI.Notifications;

namespace AdaptiveTileExtensions.Support
{
    public interface ITileNotificationFactory
    {
        TileNotification Create( Tile tile );
    }
}