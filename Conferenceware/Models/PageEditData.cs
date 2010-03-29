using System.Collections.Generic;

namespace Conferenceware.Models
{
	/// <summary>
	/// Class for creating/editting pages
	/// </summary>
	public class PageEditData
	{
		/// <summary>
		/// The page being editted/created
		/// </summary>
		public Page Page
		{
			get;
			set;
		}

		/// <summary>
		/// A list of the existing pages to be used in creation of a parent for the page
		/// </summary>
		public IEnumerable<Page> ExistingPages
		{
			get;
			set;
		}
	}
}