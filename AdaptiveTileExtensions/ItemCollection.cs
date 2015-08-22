using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace AdaptiveTileExtensions
{
	// [DataContract( Namespace = Defaults.Namespace )]
	public class ItemCollection : Collection<Item>
	{
		readonly Type[] allowedTypes = new Type[0];

		public ItemCollection( params Type[] allowedTypes )
		{
			this.allowedTypes = allowedTypes;
		}

		public ItemCollection()
		{}

		protected override void InsertItem( int index, Item item )
		{
			Guard( item );
			base.InsertItem( index, item );
		}

		protected override void SetItem( int index, Item item )
		{
			Guard( item );
			base.SetItem( index, item );
		}

		void Guard( Item item )
		{
			var type = item.GetType();
			if ( allowedTypes.All( x => !x.IsAssignableFrom( type ) ) )
			{
				throw new InvalidOperationException( $"Item '{type}' is an allowed type for this collection." );
			}
		}
	}
}