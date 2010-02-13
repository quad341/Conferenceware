using System.Collections.Generic;

namespace Conferenceware.Models
{
    interface IRepository
    {
        //Events
        /// <summary>
        /// Add an Event to a data repository. 
        /// Precondition: All the properties must be set.
        /// Postcondition: ID will be generated.
        /// </summary>
        /// <param name="ev">An Event object containing data to add.</param>
        void AddEvent(Event ev);
        /// <summary>
        /// Delete an Event from a data repository.
        /// Precondition: Event has it's ID property set and ID is valid.
        /// Postcondition: Event will be removed from data repository.
        /// </summary>
        /// <param name="ev">An Event object with ID property set</param>
        void DeleteEvent(Event ev);
        /// <summary>
        /// Delete an Event from a data repository.
        /// Precondition: ID is valid.
        /// Postcondition: Event will be removed from data repository.
        /// </summary>
        /// <param name="id">An ID associated to an Event.</param>
        void DeleteEvent(int id);
        /// <summary>
        /// Update an existing Event in a data repository.
        /// Precondition: Event exists, Event object has changed properties set.
        /// Postcondition: Event properties will be updated in the data repository.
        /// </summary>
        /// <param name="ev">An Event object with updated properties.</param>
        void UpdateEvent(Event ev);
        /// <summary>
        /// Get an Event object from the data repository.
        /// Precondition: ID is for an existing Event.
        /// </summary>
        /// <param name="id">A valid ID for an existing Event</param>
        /// <returns>An Event object with data from the repository.</returns>
        Event GetEventById(int id);
        /// <summary>
        /// Get all Event objects from the data repository.
        /// </summary>
        /// <returns>A List object containing all Event objects from the data repository.</returns>
        List<Event> GetAllEvents();

        //Attendees
        /// <summary>
        /// Add an Attendee to a data repository. 
        /// Precondition: All the properties must be set.
        /// Postcondition: ID will be generated.
        /// </summary>
        /// <param name="attendee">An Attendee object containing data to add.</param>
        void AddAttendee(Attendee attendee);
        /// <summary>
        /// Delete an Attendee from a data repository.
        /// Precondition: Attendee has it's ID property set and ID is valid.
        /// Postcondition: Attendee will be removed from data repository.
        /// </summary>
        /// <param name="attendee">An Attendee object with ID property set</param>
        void DeleteAttendee(Attendee attendee);
        /// <summary>
        /// Delete an Attendee from a data repository.
        /// Precondition: ID is valid.
        /// Postcondition: Attendee will be removed from data repository.
        /// </summary>
        /// <param name="id">An ID associated to an Attendee.</param>
        void DeleteAttendee(int id);
        /// <summary>
        /// Update an existing Attendee in a data repository.
        /// Precondition: Attendee exists, Attendee object has changed properties set.
        /// Postcondition: Attendee properties will be updated in the data repository.
        /// </summary>
        /// <param name="attendee">An Attendee object with updated properties.</param>
        void UpdateAttendee(Attendee attendee);
        /// <summary>
        /// Get an Attendee object from the data repository.
        /// Precondition: ID is for an existing Attendee.
        /// </summary>
        /// <param name="id">A valid ID for an existing Attendee</param>
        /// <returns>An Attendee object with data from the repository.</returns>
        Attendee GetAttendeeById(int id);
        /// <summary>
        /// Get all Attendee objects from the data repository.
        /// </summary>
        /// <returns>A List object containing all Attendee objects from the data repository.</returns>
        List<Attendee> GetAllAttendees();

        //Locations
        /// <summary>
        /// Add a Location to a data repository. 
        /// Precondition: All the properties must be set.
        /// Postcondition: ID will be generated.
        /// </summary>
        /// <param name="location">A Location object containing data to add.</param>
        void AddLocation(Location location);
        /// <summary>
        /// Delete a Location from a data repository.
        /// Precondition: Location has it's ID property set and ID is valid.
        /// Postcondition: Location will be removed from data repository.
        /// </summary>
        /// <param name="location">A Location object with ID property set</param>
        void DeleteLocation(Location location);
        /// <summary>
        /// Delete a Location from a data repository.
        /// Precondition: ID is valid.
        /// Postcondition: Location will be removed from data repository.
        /// </summary>
        /// <param name="id">An ID associated to a Location.</param>
        void DeleteLocation(int id);
        /// <summary>
        /// Update an existing Location in a data repository.
        /// Precondition: Location exists, Location object has changed properties set.
        /// Postcondition: Location properties will be updated in the data repository.
        /// </summary>
        /// <param name="location">A Location object with updated properties.</param>
        void UpdateLocation(Location location);
        /// <summary>
        /// Get a Location object from the data repository.
        /// Precondition: ID is for an existing Location.
        /// </summary>
        /// <param name="id">A valid ID for an existing Location</param>
        /// <returns>A Location object with data from the repository.</returns>
        Location GetLocationById(int id);
        /// <summary>
        /// Get all Location objects from the data repository.
        /// </summary>
        /// <returns>A List object containing all Location objects from the data repository.</returns>
        List<Location> GetAllLocations();
        
        //TimeSlots
        /// <summary>
        /// Add a TimeSlot to a data repository. 
        /// Precondition: All the properties must be set.
        /// Postcondition: ID will be generated.
        /// </summary>
        /// <param name="timeslot">A TimeSlot object containing data to add.</param>
        void AddTimeSlot(TimeSlot timeslot);
        /// <summary>
        /// Delete a TimeSlot from a data repository.
        /// Precondition: TimeSlot has it's ID property set and ID is valid.
        /// Postcondition: TimeSlot will be removed from data repository.
        /// </summary>
        /// <param name="timeslot">A TimeSlot object with ID property set</param>
        void DeleteTimeSlot(TimeSlot timeslot);
        /// <summary>
        /// Delete a TimeSlot from a data repository.
        /// Precondition: ID is valid.
        /// Postcondition: TimeSlot will be removed from data repository.
        /// </summary>
        /// <param name="id">An ID associated to a TimeSlot.</param>
        void DeleteTimeSlot(int id);
        /// <summary>
        /// Update an existing TimeSlot in a data repository.
        /// Precondition: TimeSlot exists, TimeSlot object has changed properties set.
        /// Postcondition: TimeSlot properties will be updated in the data repository.
        /// </summary>
        /// <param name="timeslot">A TimeSlot object with updated properties.</param>
        void UpdateTimeSlot(TimeSlot timeslot);
        /// <summary>
        /// Get a TimeSlot object from the data repository.
        /// Precondition: ID is for an existing TimeSlot.
        /// </summary>
        /// <param name="id">A valid ID for an existing TimeSlot</param>
        /// <returns>A TimeSlot object with data from the repository.</returns>
        TimeSlot GetTimeSlotById(int id);
        /// <summary>
        /// Get all TimeSlot objects from the data repository.
        /// </summary>
        /// <returns>A List object containing all TimeSlot objects from the data repository.</returns>
        List<TimeSlot> GetAllTimeSlots();

        //Speakers
        /// <summary>
        /// Add a Speaker to a data repository. 
        /// Precondition: All the properties must be set.
        /// Postcondition: ID will be generated.
        /// </summary>
        /// <param name="speaker">A Speaker object containing data to add.</param>
        void AddSpeaker(Speaker speaker);
        /// <summary>
        /// Delete a Speaker from a data repository.
        /// Precondition: Speaker has it's ID property set and ID is valid.
        /// Postcondition: Speaker will be removed from data repository.
        /// </summary>
        /// <param name="speaker">A Speaker object with ID property set</param>
        void DeleteSpeaker(Speaker speaker);
        /// <summary>
        /// Delete a Speaker from a data repository.
        /// Precondition: ID is valid.
        /// Postcondition: Speaker will be removed from data repository.
        /// </summary>
        /// <param name="id">An ID associated to a Speaker.</param>
        void DeleteSpeaker(int id);
        /// <summary>
        /// Update an existing Speaker in a data repository.
        /// Precondition: Speaker exists, Speaker object has changed properties set.
        /// Postcondition: Speaker properties will be updated in the data repository.
        /// </summary>
        /// <param name="speaker">A Speaker object with updated properties.</param>
        void UpdateSpeaker(Speaker speaker);
        /// <summary>
        /// Get a Speaker object from the data repository.
        /// Precondition: ID is for an existing Speaker.
        /// </summary>
        /// <param name="id">A valid ID for an existing Speaker</param>
        /// <returns>A Speaker object with data from the repository.</returns>
        Speaker GetSpeakerById(int id);
        /// <summary>
        /// Get all Speaker objects from the data repository.
        /// </summary>
        /// <returns>A List object containing all Speaker objects from the data repository.</returns>
        List<Speaker> GetAllSpeakers();

        //RegisterMethods
        /// <summary>
        /// Registers an Attendee to an Event.
        /// Precondition: Attendee and Event must have valid IDs.
        /// Postcondition: The Attendee is linked to the Event.
        /// </summary>
        /// <param name="attendee">An Attendee object with a valid ID from the repository</param>
        /// <param name="ev">An Event object with a valid ID from the respository</param>
        void RegisterAttendeeForEvent(Attendee attendee, Event ev);
        /// <summary>
        /// Registers a Speaker to an Event.
        /// Precondition: Speaker and Event must have valid IDs.
        /// Postcondition: The Speaker is linked to the Event. 
        /// </summary>
        /// <param name="speaker">A Speaker object with a valid ID from the repository</param>
        /// <param name="ev">An Event object with a valid ID from the respository</param>
        void RegisterSpeakerForEvent(Speaker speaker, Event ev);

    }
}
