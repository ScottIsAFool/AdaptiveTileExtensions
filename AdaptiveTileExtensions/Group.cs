using AdaptiveTileExtensions.Support;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Markup;

namespace AdaptiveTileExtensions
{
    [ContentProperty( Name = "Children" )]
    [DataContract( Namespace = Defaults.Namespace )]
    public class Group : Item
    {
        public Group()
        {
            Children = new ItemCollection( AllowedTypes );
        }

        [DataMember]
        public Collection<Item> Children { get; set; }

        protected virtual Type[] AllowedTypes => new[] { typeof(SubGroup) };
    }
}