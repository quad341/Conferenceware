using System;
using System.Linq;

namespace Conferenceware.Models
{
	public class ConferencewareRepository : IRepository
	{
		private readonly ConferencewareDataContext _conferenceware;

		public ConferencewareRepository() : this(new ConferencewareDataContext())
		{
			// no additional actions needed
		}

		public ConferencewareRepository(ConferencewareDataContext context)
		{
			_conferenceware = context;
		}

		public void AddEvent(Event ev)
		{
			throw new NotImplementedException();
		}

		public void DeleteEvent(Event ev)
		{
			throw new NotImplementedException();
		}

		public void DeleteEvent(int id)
		{
			throw new NotImplementedException();
		}

		public Event GetEventById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Event> GetAllEvents()
		{
			throw new NotImplementedException();
		}

		public void AddAttendee(Attendee attendee)
		{
			throw new NotImplementedException();
		}

		public void DeleteAttendee(Attendee attendee)
		{
			throw new NotImplementedException();
		}

		public void DeleteAttendee(int id)
		{
			throw new NotImplementedException();
		}

		public Attendee GetAttendeeById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Attendee> GetAllAttendees()
		{
			throw new NotImplementedException();
		}

		public void AddLocation(Location location)
		{
			_conferenceware.Locations.InsertOnSubmit(location);
		}

		public void DeleteLocation(Location location)
		{
			_conferenceware.Locations.DeleteOnSubmit(location);
		}

		public void DeleteLocation(int id)
		{
			DeleteLocation(GetLocationById(id));
		}

		public Location GetLocationById(int id)
		{
			return _conferenceware.Locations.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<Location> GetAllLocations()
		{
			return _conferenceware.Locations.AsQueryable();
		}

		public void AddTimeSlot(TimeSlot timeslot)
		{
            _conferenceware.TimeSlots.InsertOnSubmit(timeslot);
		}

		public void DeleteTimeSlot(TimeSlot timeslot)
		{
            _conferenceware.TimeSlots.DeleteOnSubmit(timeslot);
		}

		public void DeleteTimeSlot(int id)
		{
            DeleteTimeSlot(GetTimeSlotById(id));
		}

		public TimeSlot GetTimeSlotById(int id)
		{
            return _conferenceware.TimeSlots.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<TimeSlot> GetAllTimeSlots()
		{
            return _conferenceware.TimeSlots.AsQueryable();
		}

		public void AddSpeaker(Speaker speaker)
		{
            _conferenceware.Speakers.InsertOnSubmit(speaker);
		}

		public void DeleteSpeaker(Speaker speaker)
		{
            DeletePerson(speaker.person_id);
            _conferenceware.Speakers.DeleteOnSubmit(speaker);
		}

		public void DeleteSpeaker(int id)
		{
            DeleteSpeaker(GetSpeakerById(id));
		}

		public Speaker GetSpeakerById(int id)
		{
            return _conferenceware.Speakers.SingleOrDefault(x => x.person_id == id);
		}

		public IQueryable<Speaker> GetAllSpeakers()
		{
			throw new NotImplementedException();
		}

		public void RegisterAttendeeForEvent(Attendee attendee, Event ev)
		{
			throw new NotImplementedException();
		}

		public void RegisterSpeakerForEvent(Speaker speaker, Event ev)
		{
			throw new NotImplementedException();
		}

        public void DeletePerson(People person)
        {
            _conferenceware.Peoples.DeleteOnSubmit(person);
        }

        public void DeletePerson(int id)
        {
            DeletePerson(GetPersonById(id));
        }

        public People GetPersonById(int id)
        {
            return _conferenceware.Peoples.SingleOrDefault(x => x.id == id);
        }

		public void Save()
		{
			_conferenceware.SubmitChanges();
		}
	}

}