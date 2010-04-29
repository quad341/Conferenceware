using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	/// <summary>
	/// Partial class for convenience functions and validation of Location
	/// </summary>
	[MetadataType(typeof(LocationMetadata))]
	public partial class Location
	{
		// linq takes care of everything
		// do _not_ add other properties. it will give you the rage of posidon because of the errors
		public string StringValue
		{
			get { return ToString(); }
		}

		public override string ToString()
		{
			return building_name + ": " + room_number;
		}
	}
}