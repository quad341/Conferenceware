using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Utils
{
	/// <summary>
	/// Attribute to ensure a string contains the provided value
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	sealed public class StringContainsAttribute : ValidationAttribute 
	{
		readonly IEnumerable<String> _searchList;

		public StringContainsAttribute(params string[] searchList)
		{
			_searchList = searchList;
		}

		public override bool IsValid(object value)
		{
			if (value != null)
			{
				var toValidate = (String)value;
				foreach (var search in _searchList)
				{
					if (!toValidate.Contains(search))
					{
						return false;
					}
				}
			}
			// only the [Required] attribute means value can't be null
			return true;
		}
	}
}