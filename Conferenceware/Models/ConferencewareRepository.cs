using System;
using System.Linq;

namespace Conferenceware.Models
{
	public class ConferencewareRepository : IRepository
	{
		private readonly ConferencewareDataContext _conferenceware;

		public ConferencewareRepository()
			: this(new ConferencewareDataContext())
		{
			// no additional actions needed
		}

		public ConferencewareRepository(ConferencewareDataContext context)
		{
			_conferenceware = context;
		}

		public void AddEvent(Event ev)
		{
			_conferenceware.Events.InsertOnSubmit(ev);
		}

		public void DeleteEvent(Event ev)
		{
			_conferenceware.Events.DeleteOnSubmit(ev);
		}

		public void DeleteEvent(int id)
		{
			DeleteEvent(GetEventById(id));
		}

		public Event GetEventById(int id)
		{
			return _conferenceware.Events.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<Event> GetAllEvents()
		{
			return _conferenceware.Events.AsQueryable();
		}

		public void AddAttendee(Attendee attendee)
		{
			_conferenceware.Attendees.InsertOnSubmit(attendee);
		}

		public void DeleteAttendee(Attendee attendee)
		{
			DeletePerson(attendee.person_id);
			_conferenceware.Attendees.DeleteOnSubmit(attendee);
		}

		public void DeleteAttendee(int id)
		{
			DeleteAttendee(GetAttendeeById(id));
		}

		public Attendee GetAttendeeById(int id)
		{
			return _conferenceware.Attendees.SingleOrDefault(x => x.person_id == id);
		}

		public IQueryable<Attendee> GetAllAttendees()
		{
			return _conferenceware.Attendees.AsQueryable();
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
			return _conferenceware.Speakers.AsQueryable();
		}

		public void RegisterAttendeeForEvent(Attendee attendee, Event ev)
		{
			var eva =
				_conferenceware.EventsAttendees.SingleOrDefault(
					x => x.Attendee == attendee && x.Event == ev);
			if (eva == null)
			{
				eva = new EventsAttendee { Attendee = attendee, Event = ev };
				_conferenceware.EventsAttendees.InsertOnSubmit(eva);
			}
		}

		public void UnRegisterAttendeeForEvent(Attendee attendee, Event ev)
		{
			var eva =
				_conferenceware.EventsAttendees.SingleOrDefault(
					x => x.Attendee == attendee && x.Event == ev);
			_conferenceware.EventsAttendees.DeleteOnSubmit(eva);
		}

		public void RegisterSpeakerForEvent(Speaker speaker, Event ev)
		{
			var evs =
				_conferenceware.EventsSpeakers.SingleOrDefault(
					x => x.Speaker == speaker && x.Event == ev);
			if (evs == null)
			{
				evs = new EventsSpeaker { Speaker = speaker, Event = ev };
				_conferenceware.EventsSpeakers.InsertOnSubmit(evs);
			}
		}

		public void UnRegisterSpeakerForEvent(Speaker speaker, Event ev)
		{
			var evs =
				_conferenceware.EventsSpeakers.SingleOrDefault(
					x => x.Speaker == speaker && x.Event == ev);
			_conferenceware.EventsSpeakers.DeleteOnSubmit(evs);
		}

		public void AddFood(Food food)
		{
			_conferenceware.Foods.InsertOnSubmit(food);
		}

		public void DeleteFood(Food food)
		{
			_conferenceware.Foods.DeleteOnSubmit(food);
		}

		public void DeleteFood(int id)
		{
			DeleteFood(GetFoodById(id));
		}

		public Food GetFoodById(int id)
		{
			return _conferenceware.Foods.SingleOrDefault(f => f.id == id);
		}

		public IQueryable<Food> GetAllFoods()
		{
			return _conferenceware.Foods.AsQueryable();
		}

		public void AddTShirtSize(TShirtSize t)
		{
			_conferenceware.TShirtSizes.InsertOnSubmit(t);
		}

		public void DeleteTShirtSize(TShirtSize tshirtsize)
		{
			_conferenceware.TShirtSizes.DeleteOnSubmit(tshirtsize);
		}

		public void DeleteTShirtSize(int id)
		{
			DeleteTShirtSize(GetTShirtSizeById(id));
		}

		public TShirtSize GetTShirtSizeById(int id)
		{
			return _conferenceware.TShirtSizes.SingleOrDefault(t => t.id == id);
		}

		public IQueryable<TShirtSize> GetAllTShirtSizes()
		{
			return _conferenceware.TShirtSizes.AsQueryable();
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