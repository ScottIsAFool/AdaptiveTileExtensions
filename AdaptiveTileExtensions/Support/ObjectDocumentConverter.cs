using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Windows.Data.Xml.Dom;

namespace AdaptiveTileExtensions.Support
{
	class ObjectDocumentConverter : IObjectDocumentConverter
	{
		public static ObjectDocumentConverter Instance { get; } = new ObjectDocumentConverter();

		public XmlDocument Convert( object source )
		{
			using ( var stream = new MemoryStream() )
			{
				var serializer = new DataContractSerializer( source.GetType() );
				serializer.WriteObject( stream, source, new Dictionary<string, string> { {  "a", "http://www.w3.org/2001/XMLSchema" } } );
				stream.Position = 0;
				using ( var reader = new StreamReader( stream ) )
				{
					var result = new XmlDocument();
					var data = reader.ReadToEnd();
					result.LoadXml( data );
					return result;
				}
			}
		}
	}
}