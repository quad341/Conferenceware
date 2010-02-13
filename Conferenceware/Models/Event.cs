using System.Collections.Generic;

namespace Conferenceware.Models
{
	public partial class Event
	{
		/// <summary>
		/// Convenient property for getting the attendees for an event
		/// </summary>
		List<Attendee> Attendees
		{
			get
			{
				var attendees = new List<Attendee>();
				foreach (EventsAttendee ea in EventsAttendees)
				{
					attendees.Add(ea.Attendee);
				}
				return attendees;
			}
		}

		/// <summary>
		/// Convenient property for getting the speakers for an event
		/// </summary>
		List<Speaker> Speakers
		{
			get
			{
				var speakers = new List<Speaker>();
				foreach (EventsSpeaker es in EventsSpeakers)
				{
					speakers.Add(es.Speaker);
				}
				return speakers;
			}
		}
	}
}