using System;
using System.Collections.Generic;
using System.Linq;
using Conferenceware.Models;

namespace Conferenceware.Tests.Models
{
	class TestRepository : IRepository
	{
		/// <summary>
		/// Internal storage for locations in memory
		/// </summary>
		private List<Location> _locations = new List<Location>();

		/// <summary>
		/// The last used Id for locations
		/// </summary>
		private int _locationMaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for timeslots.
		/// </summary>
		private List<TimeSlot> _timeslots = new List<TimeSlot>();
		private int _timeslotmaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for events.
		/// </summary>
		private List<Event> _events = new List<Event>();
		private int _eventMaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for attendees.
		/// </summary>
		private List<Attendee> _attendees = new List<Attendee>();
		private int _attendeeMaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for speakers.
		/// </summary>
		private List<Speaker> _speakers = new List<Speaker>();
		private int _speakerMaxId = 0;

		public void AddEvent(Event ev)
		{
			ev.id = ++_eventMaxId;
			_events.Add(ev);
		}

		public void DeleteEvent(Event ev)
		{
			_events.Remove(ev);
		}

		public void DeleteEvent(int id)
		{
			DeleteEvent(GetEventById(id));
		}

		public Event GetEventById(int id)
		{
			return _events.SingleOrDefault<Event>(x => x.id == id);
		}

		public IQueryable<Event> GetAllEvents()
		{
			return _events.AsQueryable();
		}

		public void AddAttendee(Attendee attendee)
		{
			attendee.People.id = ++_attendeeMaxId;
			_attendees.Add(attendee);
		}

		public void DeleteAttendee(Attendee attendee)
		{
			_attendees.Remove(attendee);
		}

		public void DeleteAttendee(int id)
		{
			DeleteAttendee(GetAttendeeById(id));
		}

		public Attendee GetAttendeeById(int id)
		{
			return _attendees.SingleOrDefault(x => id == x.People.id);
		}

		public IQueryable<Attendee> GetAllAttendees()
		{
			return _attendees.AsQueryable();
		}

		public void AddLocation(Location location)
		{
			location.id = ++_locationMaxId;
			_locations.Add(location);
		}

		public void DeleteLocation(Location location)
		{
			_locations.Remove(location);
		}

		public void DeleteLocation(int id)
		{
			DeleteLocation(GetLocationById(id));
		}

		public Location GetLocationById(int id)
		{
			return _locations.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<Location> GetAllLocations()
		{
			return _locations.AsQueryable();
		}

		public void AddTimeSlot(TimeSlot timeslot)
		{
			timeslot.id = ++_timeslotmaxId;
			_timeslots.Add(timeslot);
		}

		public void DeleteTimeSlot(TimeSlot timeslot)
		{
			_timeslots.Remove(timeslot);
		}

		public void DeleteTimeSlot(int id)
		{
			DeleteTimeSlot(GetTimeSlotById(id));
		}

		public TimeSlot GetTimeSlotById(int id)
		{
			return _timeslots.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<TimeSlot> GetAllTimeSlots()
		{
			return _timeslots.AsQueryable();
		}

		public void AddSpeaker(Speaker speaker)
		{
			speaker.People.id = ++_speakerMaxId;
			_speakers.Add(speaker);
		}

		public void DeleteSpeaker(Speaker speaker)
		{
			_speakers.Remove(speaker);
		}

		public void DeleteSpeaker(int id)
		{
			DeleteSpeaker(GetSpeakerById(id));
		}

		public Speaker GetSpeakerById(int id)
		{
			return _speakers.SingleOrDefault(x => x.People.id == id);
		}

		public IQueryable<Speaker> GetAllSpeakers()
		{
			return _speakers.AsQueryable();
		}

		public void RegisterAttendeeForEvent(Attendee attendee, Event ev)
		{
			var eva = new EventsAttendee();
			eva.Attendee = attendee;
			eva.Event = ev;
			ev.EventsAttendees.Insert(0, eva);
			attendee.EventsAttendees.Insert(0, eva);
		}

		public void RegisterSpeakerForEvent(Speaker speaker, Event ev)
		{
			var evs = new EventsSpeaker();
			evs.Speaker = speaker;
			evs.Event = ev;
			ev.EventsSpeakers.Insert(0, evs);
			speaker.EventsSpeakers.Insert(0, evs);
		}

		public void AddFood(Food food)
		{
			throw new NotImplementedException();
		}

		public void DeleteFood(Food food)
		{
			throw new NotImplementedException();
		}

		public void DeleteFood(int id)
		{
			throw new NotImplementedException();
		}

		public Food GetFoodById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Food> GetAllFoods()
		{
			throw new NotImplementedException();
		}

		public void AddTShirtSize(TShirtSize t)
		{
			throw new NotImplementedException();
		}

		public void DeleteTShirtSize(TShirtSize tshirtsize)
		{
			throw new NotImplementedException();
		}

		public void DeleteTShirtSize(int id)
		{
			throw new NotImplementedException();
		}

		public TShirtSize GetTShirtSizeById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<TShirtSize> GetAllTShirtSizes()
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			// we do that anyway. we might want to do something more interesting 
			// with validation, etc.
		}
	}
}
