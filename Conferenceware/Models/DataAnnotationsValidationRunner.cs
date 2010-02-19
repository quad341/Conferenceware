using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using xVal.ServerSide;

namespace Conferenceware.Models
{
	internal static class DataAnnotationsValidationRunner
	{
		 // from http://goneale.wordpress.com/2009/03/04/using-metadatatype-attribute-with-aspnet-mvc-xval-validation-framework/ 
         /// <summary> 
         /// Get any errors associated with the model also investigating any rules dictated by attached Metadata buddy classes. 
         /// </summary> 
         /// <param name="instance">The object to check</param> 
         /// <returns>A list of errors for the object</returns> 
         public static IEnumerable<ErrorInfo> GetErrors (object instance) 
         { 
             var metadataAttrib = instance.GetType().GetCustomAttributes(typeof(MetadataTypeAttribute), true).OfType<MetadataTypeAttribute>().FirstOrDefault(); 
             var buddyClassOrModelClass = metadataAttrib != null ? metadataAttrib.MetadataClassType : instance.GetType(); 
             var buddyClassProperties = TypeDescriptor.GetProperties(buddyClassOrModelClass).Cast<PropertyDescriptor>(); 
             var modelClassProperties = TypeDescriptor.GetProperties(instance.GetType()).Cast<PropertyDescriptor>(); 
  
             return from buddyProp in buddyClassProperties 
                    join modelProp in modelClassProperties on buddyProp.Name equals modelProp.Name 
                    from attribute in buddyProp.Attributes.OfType<ValidationAttribute>() 
                    where !attribute.IsValid(modelProp.GetValue(instance)) 
                    select new ErrorInfo(buddyProp.Name, attribute.FormatErrorMessage(string.Empty), instance); 
         } 
 

	}

}