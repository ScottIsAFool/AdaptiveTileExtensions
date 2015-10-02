using AdaptiveTileExtensions.Support;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;

namespace AdaptiveTileExtensions.Testing
{
	[TestClass]
	public class ObjectDocumentConverterTests
	{
		[TestMethod]
		public async Task Convert()
		{
			await Dispatch.OnPrimary( async () =>
			{
				await Defaults.Initialize();

				Assert.IsNotNull( Defaults.Processor );
				var document = new ObjectDocumentConverter().Convert( new Tile() );
				var actual = document.GetXml();
				Assert.AreEqual( Resources.ExpectedXml.Trim(), actual );
			} );
		}

		[TestMethod]
		public async Task Transform()
		{
			await Dispatch.OnPrimary( async () =>
			{
				await Defaults.Initialize();

				Assert.IsNotNull( Defaults.Processor );
				var document = new ObjectDocumentConverter().Convert( new Tile() );
				
				var actual = Defaults.Processor.TransformToString( document );
				Assert.AreEqual( ToXmlString( Resources.ExpectedTransform ), ToXmlString( actual ) );
			} );
		}

		static string ToXmlString( string input )
		{
			var document = new XmlDocument();
			document.LoadXml( input.Trim(), new XmlLoadSettings { ElementContentWhiteSpace = false } );
			var result = document.GetXml();
			return result;
		}
	}
}
