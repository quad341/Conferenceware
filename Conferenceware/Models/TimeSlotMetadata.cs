using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class TimeSlotMetadata
	{
		// datetime ranges based on sql ranges. without them you get the following error:
		// Must be between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM.
		[Required]
		[DataType(DataType.DateTime)]
		[DisplayName("Start Time")]
		[Range(typeof(DateTime), "1/1/2000", "12/31/9999")]
		public DateTime start_time
		{
			get;
			set;
		}

		[Required]
		[DataType(DataType.DateTime)]
		[DisplayName("End Time")]
		[Range(typeof(DateTime), "1/1/2000", "12/31/9999")]
		public DateTime end_time
		{
			get;
			set;
		}
	}
}