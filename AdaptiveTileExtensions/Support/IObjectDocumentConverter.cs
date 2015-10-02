using Windows.Data.Xml.Dom;

namespace AdaptiveTileExtensions.Support
{
	public interface IObjectDocumentConverter
	{
		XmlDocument Convert( object source );
	}

	
}