using System;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace AdaptiveTileExtensions.Support
{
	public static class Dispatch
	{
		public static void OnPrimary( Action action )
		{
			OnPrimary( () => Task.Run( action ) );
		}

		public static Task OnPrimary( Func<Task> action )
		{
			var source = new TaskCompletionSource<bool>();
			var dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
			dispatcher.RunAsync( CoreDispatcherPriority.Normal, async () =>
			{
				try
				{
					await action();

					source.SetResult( true );
				}
				catch ( Exception e )
				{
					source.SetException( e );
				}
			} );
			return source.Task;
		}
	}
}