using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	public class TimeSlotMetadata
	{
		[Required]
		[DataType(DataType.DateTime)]
		[DisplayName("Start Time")]
		public DateTime start_time
		{
			get; set;
		}

		[Required]
		[DataType(DataType.DateTime)]
		[DisplayName("End Time")]
		public DateTime end_time
		{
			get; set;
		}
	}
}