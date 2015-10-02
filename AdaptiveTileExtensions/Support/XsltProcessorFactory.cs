using System;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Data.Xml.Xsl;
using Windows.Storage;

namespace AdaptiveTileExtensions.Support
{
	public class XsltProcessorFactory
	{
		readonly Uri uri;

		public XsltProcessorFactory( Uri uri )
		{
			this.uri = uri;
		}

		public async Task<XsltProcessor> Create()
		{
			var file = await StorageFile.GetFileFromApplicationUriAsync( uri );
			var xmlDocument = await XmlDocument.LoadFromFileAsync( file );
			var result = new XsltProcessor( xmlDocument );
			return result;
		}
	}
}