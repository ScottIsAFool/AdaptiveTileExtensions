using System;
using System.Reflection;

namespace AdaptiveTileExtensions.Support
{
	public static class Compensations
	{
		public static T Convert<T>( this object @this )
		{
			if ( @this != null )
			{
				var targetType = Nullable.GetUnderlyingType( typeof(T) ) ?? typeof(T);
				var result = targetType.IsInstanceOfType( @this ) ? @this : typeof(Enum).IsAssignableFrom( targetType ) && @this is string ? Enum.Parse( targetType, (string)@this ) :
					System.Convert.ChangeType( @this, targetType );
				return (T)result;
			}
			return default(T);
		}
	}
}