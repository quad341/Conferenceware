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

		IQueryable<Event> IRepository.GetAllEvents()
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

		IQueryable<Attendee> IRepository.GetAllAttendees()
		{
			throw new NotImplementedException();
		}

		public IQueryable<Attendee> GetAllAttendees()
		{
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public void DeleteSpeaker(Speaker speaker)
		{
			throw new NotImplementedException();
		}

		public void DeleteSpeaker(int id)
		{
			throw new NotImplementedException();
		}

		public Speaker GetSpeakerById(int id)
		{
			throw new NotImplementedException();
		}

		IQueryable<Speaker> IRepository.GetAllSpeakers()
		{
			throw new NotImplementedException();
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

		public void Save()
		{
			// we do that anyway. we might want to do something more interesting 
			// with validation, etc.
		}
	}
}
