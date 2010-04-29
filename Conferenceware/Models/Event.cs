using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Conferenceware.Models
{
	[MetadataType(typeof(EventMetadata))]
	public partial class Event
	{
		// go go linq
		/// <summary>
		/// Convenience method for getting all the attendees for a talk
		/// </summary>
		public IQueryable<Attendee> Attendees
		{
			get { return EventsAttendees.Select(ea => ea.Attendee).AsQueryable(); }
		}

		/// <summary>
		/// Convenience method for getting all the speakers for a talk
		/// </summary>
		public IQueryable<Speaker> Speakers
		{
			get { return EventsSpeakers.Select(es => es.Speaker).AsQueryable(); }
		}
	}
}