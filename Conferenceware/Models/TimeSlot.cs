using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	[MetadataType(typeof(TimeSlotMetadata))]
	public partial class TimeSlot
	{
		// linq will do most things here
		public string StringValue
		{
			get
			{
				return ToString();
			}
		}
		public override string ToString()
		{
			return start_time + " to " + end_time;
		}
	}
}