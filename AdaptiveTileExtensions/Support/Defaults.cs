using System;
using System.Threading.Tasks;
using Windows.Data.Xml.Xsl;

namespace AdaptiveTileExtensions.Support
{
	public static class Defaults
	{
		public const string Namespace = "https://github.com/ScottIsAFool/AdaptiveTileExtensions";

		static readonly Task<XsltProcessor> Task = new XsltProcessorFactory( new Uri( Resources.TileNotificationFactory_XsltPath ) ).Create();

		public static XsltProcessor Processor => Task.IsCompleted ? Task.Result : null;

		public static Task Initialize()
		{
			return System.Threading.Tasks.Task.WhenAll( Task );
		}
	}
}