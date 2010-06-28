using System;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Utils
{
	/// <summary>
	/// Attribute to ensure a string contains the provided value
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	sealed public class StringContainsAttribute : ValidationAttribute 
	{
		readonly string _search;

		public StringContainsAttribute(string search)
		{
			_search = search;
		}

		public override bool IsValid(object value)
		{
			if (value != null)
			{
				var toValidate = (String)value;
				return toValidate.Contains(_search);
			}
			// only the [Required] attribute means value can't be null
			return true;
		}
	}
}