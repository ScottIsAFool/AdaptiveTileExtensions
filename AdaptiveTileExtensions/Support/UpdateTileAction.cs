using Microsoft.Xaml.Interactivity;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace AdaptiveTileExtensions.Support
{
	[ContentProperty( Name = "Tile" )]
	public class UpdateTileAction : DependencyObject, IAction
	{
		public object Execute( object sender, object parameter )
		{
			if ( Tile != null )
			{
				var notification = Factory.Create( Tile );
				TileUpdateManager.CreateTileUpdaterForApplication().Update( notification );
				return true;
			}

			return false;
		}

		public Tile Tile
		{
			get { return (Tile)GetValue( TileProperty ); }
			set { SetValue( TileProperty, value ); }
		}	public static readonly DependencyProperty TileProperty = DependencyProperty.Register( "Tile", typeof(Tile), typeof(UpdateTileAction), null );
		
		public ITileNotificationFactory Factory
		{
			get { return (ITileNotificationFactory)GetValue( FactoryProperty ); }
			set { SetValue( FactoryProperty, value ); }
		}	public static readonly DependencyProperty FactoryProperty = DependencyProperty.Register( "Factory", typeof(ITileNotificationFactory), typeof(UpdateTileAction), new PropertyMetadata( TileNotificationFactory.Instance ) );
	}
}