using System;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	[MetadataType(typeof(AttendeeMetadata))]
	public partial class Attendee
	{
		// linq will do most things here
		public bool Equals(Object obj)
		{
			if (obj is Attendee)
			{
				var compare = obj as Attendee;

				if (People.Equals(compare.People) &&
					tshirt_id == compare.tshirt_id &&
					food_choice_id == compare.food_choice_id &&
					person_id == compare.food_choice_id)
				{
					return true;
				}
			}

			return false;
		}
	}
}