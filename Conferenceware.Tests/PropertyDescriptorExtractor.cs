using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Conferenceware.Tests
{
	/// <summary>
	/// Class for getting property descriptors from a class easier
	/// </summary>
	internal static class PropertyDescriptorExtractor
	{
		// based on ideas from http://bradwilson.typepad.com/blog/2009/04/dataannotations-and-aspnet-mvc.html
		// and code from http://goneale.wordpress.com/2009/03/04/using-metadatatype-attribute-with-aspnet-mvc-xval-validation-framework/ 
		public static IEnumerable<PropertyDescriptor> GetPropertyInfo(Type t)
		{
			var metadataAttrib =
				t.GetCustomAttributes(typeof (MetadataTypeAttribute), true).OfType
					<MetadataTypeAttribute>().FirstOrDefault();
			var buddyClassOrModelClass = metadataAttrib != null
			                             	? metadataAttrib.MetadataClassType
			                             	: t.GetType();
			var buddyClassProperties =
				TypeDescriptor.GetProperties(buddyClassOrModelClass).Cast
					<PropertyDescriptor>();
			return buddyClassProperties;
		}
	}
}