using System.ComponentModel.DataAnnotations;
using System;

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
                Attendee compare = obj as Attendee;

                if (this.People.Equals(compare.People) &&
                    this.tshirt_id == compare.tshirt_id &&
                    this.food_choice_id == compare.food_choice_id &&
                    this.person_id == compare.food_choice_id)
                {
                    return true;
                }
            }

            return false;
		}
	}

}