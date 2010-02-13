using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conferenceware.Models
{
    interface IRepository
    {
        //Events
        public void AddEvent(Event ev);
        public void DeleteEvent(Event ev);
        public void UpdateEvent(Event ev);
        public Event GetEventById(int id);
        public List<Event> GetAllEvents();

        //Attendees
        public void AddAttendee(Attendee attendee);
        public void DeleteAttendee(Attendee attendee);
        public void UpdateAttendee(Attendee attendee);
        public Attendee GetAttendeeById(int id);
        public List<Attendee> GetAllAttendees();

        //Locations
        public void AddLocation(Location location);
        public void DeleteLocation(Location location);
        public void UpdateLocation(Location location);
        public Location GetLocationById(int id);
        public List<Location> GetAllLocations();
        
        //TimeSlots
        public void AddTimeSlot(TimeSlot timeslot);
        public void DeleteTimeSlot(TimeSlot timeslot);
        public void UpdateTimeSlot(TimeSlot timeslot);
        public TimeSlot GetTimeSlotById(int id);
        public List<TimeSlot> GetAllTimeSlots();

        //Speakers
        public void AddSpeaker(Speaker speaker);
        public void DeleteSpeaker(Speaker speaker);
        public void UpdateSpeaker(Speaker speaker);
        public Speaker GetSpeakerById(int id);
        public List<Speaker> GetAllSpeakers();

        //RegisterMethods
        public void RegisterAttendeeForEvent(Attendee attendee, Event ev);
        public void RegisterSpeakerForEvent(Speaker speaker, Event ev);

    }
}
