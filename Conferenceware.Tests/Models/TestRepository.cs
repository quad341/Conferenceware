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

		public void UpdateEvent(Event ev)
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

		public void UpdateAttendee(Attendee attendee)
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
			int maxId = _locations.Max(l => l.id);
			location.id = maxId + 1;
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

		public void UpdateLocation(Location location)
		{
			var internalLocation = GetLocationById(location.id);
			internalLocation.building_name = location.building_name;
			internalLocation.max_capacity = location.max_capacity;
			internalLocation.notes = location.notes;
			internalLocation.room_number = location.room_number;
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
			throw new NotImplementedException();
		}

		public void DeleteTimeSlot(TimeSlot timeslot)
		{
			throw new NotImplementedException();
		}

		public void DeleteTimeSlot(int id)
		{
			throw new NotImplementedException();
		}

		public void UpdateTimeSlot(TimeSlot timeslot)
		{
			throw new NotImplementedException();
		}

		public TimeSlot GetTimeSlotById(int id)
		{
			throw new NotImplementedException();
		}

		IQueryable<TimeSlot> IRepository.GetAllTimeSlots()
		{
			throw new NotImplementedException();
		}

		public IQueryable<TimeSlot> GetAllTimeSlots()
		{
			throw new NotImplementedException();
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

		public void UpdateSpeaker(Speaker speaker)
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
