using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace AdaptiveTileExtensions.Support
{
	public static class Extensions
	{
		public static void WriteObject( this DataContractSerializer serializer, Stream stream, object data, IDictionary<string, string> namespaces )
		{
			using ( var writer = XmlWriter.Create( stream ) )
			{
				serializer.WriteStartObject( writer, data );
				foreach ( var pair in namespaces )
				{
					writer.WriteAttributeString( "xmlns", pair.Key, null, pair.Value );
				}
				serializer.WriteObjectContent( writer, data );
				serializer.WriteEndObject( writer );
			}
		}
	}
}