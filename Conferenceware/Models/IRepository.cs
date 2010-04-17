using System.Linq;

namespace Conferenceware.Models
{
	public interface IRepository
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
		IQueryable<Event> GetAllEvents();

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
		IQueryable<Attendee> GetAllAttendees();

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
		IQueryable<Location> GetAllLocations();

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
		IQueryable<TimeSlot> GetAllTimeSlots();

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
		IQueryable<Speaker> GetAllSpeakers();

		//RegisterMethods
		/// <summary>
		/// Registers an Attendee to an Event.
		/// Precondition: Attendee and Event must have valid IDs.
		/// Postcondition: The Attendee is linked to the Event exactly one time.
		/// </summary>
		/// <param name="attendee">An Attendee object with a valid ID from the repository</param>
		/// <param name="ev">An Event object with a valid ID from the respository</param>
		void RegisterAttendeeForEvent(Attendee attendee, Event ev);

		/// <summary>
		/// Removes the registration for an attendee from an event
		/// Precondition: Attendee and Event must have valid IDs.
		/// Postcondition: The Attendee is not linked to the event
		/// </summary>
		/// <param name="attendee">An Attendee object with a valid ID from the repository</param>
		/// <param name="ev">An Event object with a valid ID from the repository</param>
		void UnRegisterAttendeeForEvent(Attendee attendee, Event ev);

		/// <summary>
		/// Registers a Speaker to an Event.
		/// Precondition: Speaker and Event must have valid IDs.
		/// Postcondition: The Speaker is linked to the Event exactly one time. 
		/// </summary>
		/// <param name="speaker">A Speaker object with a valid ID from the repository</param>
		/// <param name="ev">An Event object with a valid ID from the respository</param>
		void RegisterSpeakerForEvent(Speaker speaker, Event ev);

		/// <summary>
		/// Removes the registration for a speaker from an event
		/// Precondition: Speaker and Event must have valid IDs.
		/// Postcondition: The Speaker is not linked to the Event.
		/// </summary>
		/// <param name="speaker">A Speaker object with a valid ID from the repository</param>
		/// <param name="ev">An Event object with a valid ID from the respository</param>
		void UnRegisterSpeakerForEvent(Speaker speaker, Event ev);

		//Foods

		/// <summary>
		/// Adds a food item to the list of possible foods.
		/// Precondition: food must have a valid ID.
		/// Postcondition: The food item is contained in the repository.
		/// </summary>
		/// <param name="food">A Food object with a valid ID from the repository</param>
		void AddFood(Food food);

		/// <summary>
		/// Deletes a food item from the repository.
		/// Precondition: Food must have a valid ID from the repository.
		/// Postcondition: The repository no longer contains that food object.
		/// </summary>
		/// <param name="food">A Food object with a valid ID from the repository</param>
		void DeleteFood(Food food);

		/// <summary>
		/// Delete a food item from the repository.
		/// Precondition: id is a valid food ID.
		/// Postcondition: The repository no longer contains a food item with that ID.
		/// </summary>
		/// <param name="id">A Food object with a valid ID from the repository</param>
		void DeleteFood(int id);

		/// <summary>
		/// Retrieve a Food object.
		/// Precondition: id is a valid food ID.
		/// </summary>
		/// <param name="id">A valid food ID from the repository.</param>
		/// <returns>A Food object with data from the repository.</returns>
		Food GetFoodById(int id);

		/// <summary>
		/// Get all Food objects from the repository.
		/// </summary>
		/// <returns>A List object containing all Food objects from the data repository.</returns>
		IQueryable<Food> GetAllFoods();

		//TShirt

		/// <summary>
		/// Adds a TShirtSize item to the list of possible TShirtSizes.
		/// Precondition: t must have a valid ID.
		/// Postcondition: The TShirtSize item is contained in the repository.
		/// </summary>
		/// <param name="t">A TShirtSize object with a valid ID from the repository</param>
		void AddTShirtSize(TShirtSize t);

		/// <summary>
		/// Deletes a TShirtSize item from the repository.
		/// Precondition: tshirtsize must have a valid ID from the repository.
		/// Postcondition: The repository no longer contains that TShirtSize object.
		/// </summary>
		/// <param name="tshirtsize">A TShirtSize object with a valid ID from the repository</param>
		void DeleteTShirtSize(TShirtSize tshirtsize);

		/// <summary>
		/// Delete a TShirtSize item from the repository.
		/// Precondition: id is a valid TShirtSize ID.
		/// Postcondition: The repository no longer contains a TShirtSize item with that ID.
		/// </summary>
		/// <param name="id">A TShirtSize object with a valid ID from the repository</param>
		void DeleteTShirtSize(int id);

		/// <summary>
		/// Retrieve a TShirtSize object.
		/// Precondition: id is a valid TShirtSize ID.
		/// </summary>
		/// <param name="id">A valid TShirtSize ID from the repository.</param>
		/// <returns>A TShirtSize object with data from the repository.</returns>
		TShirtSize GetTShirtSizeById(int id);

		/// <summary>
		/// Get all TShirtSizes objects from the repository.
		/// </summary>
		/// <returns>A List object containing all TShirtsize objects from the data repository.</returns>
		IQueryable<TShirtSize> GetAllTShirtSizes();

		//Company

		/// <summary>
		/// Adds a Company item to the repository.
		/// Precondition: c must have a valid ID.
		/// Postcondition: The Company item is contained in the repository.
		/// </summary>
		/// <param name="c">A Company object with a valid ID from the repository</param>
		void AddCompany(Company c);

		/// <summary>
		/// Deletes a Company item from the repository.
		/// Precondition: c must have a valid ID from the repository.
		/// Postcondition: The repository no longer contains that Company object.
		/// </summary>
		/// <param name="c">A Company object with a valid ID from the repository</param>
		void DeleteCompany(Company c);

		/// <summary>
		/// Delete a Company item from the repository.
		/// Precondition: id is a valid Company ID.
		/// Postcondition: The repository no longer contains a Company item with that ID.
		/// </summary>
		/// <param name="id">A Company object with a valid ID from the repository</param>
		void DeleteCompany(int id);

		/// <summary>
		/// Retrieve a Company object.
		/// Precondition: id is a valid Company ID.
		/// </summary>
		/// <param name="id">A valid Company ID from the repository.</param>
		/// <returns>A Company object with data from the repository.</returns>
		Company GetCompanyById(int id);

		/// <summary>
		/// Get all Company objects from the repository.
		/// </summary>
		/// <returns>A List object containing all Company objects from the data repository.</returns>
		IQueryable<Company> GetAllCompanies();

		//CompanyPerson

		/// <summary>
		/// Adds a CompanyPerson item to the repository.
		/// Precondition: cp must have a valid ID.
		/// Postcondition: The CompanyPerson item is contained in the repository.
		/// </summary>
		/// <param name="cp">A CompanyPerson object with a valid ID from the repository</param>
		void AddCompanyPerson(CompanyPerson cp);

		/// <summary>
		/// Deletes a CompanyPerson item from the repository.
		/// Precondition: cp must have a valid ID from the repository.
		/// Postcondition: The repository no longer contains that CompanyPerson object.
		/// </summary>
		/// <param name="cp">A CompanyPerson object with a valid ID from the repository</param>
		void DeleteCompanyPerson(CompanyPerson cp);

		/// <summary>
		/// Delete a CompanyPerson item from the repository.
		/// Precondition: id is a valid CompanyPerson ID.
		/// Postcondition: The repository no longer contains a CompanyPerson item with that ID.
		/// </summary>
		/// <param name="id">A CompanyPerson object with a valid ID from the repository</param>
		void DeleteCompanyPerson(int id);

		/// <summary>
		/// Retrieve a CompanyPerson object.
		/// Precondition: id is a valid CompanyPerson ID.
		/// </summary>
		/// <param name="id">A valid CompanyPerson ID from the repository.</param>
		/// <returns>A CompanyPerson object with data from the repository.</returns>
		CompanyPerson GetCompanyPersonById(int id);

		/// <summary>
		/// Get all CompanyPerson objects from the repository.
		/// </summary>
		/// <returns>A List object containing all CompanyPerson objects from the data repository.</returns>
		IQueryable<CompanyPerson> GetAllCompanyPersons();

		//CompanyInvoice
		void AddCompanyInvoice(CompanyInvoice ci);
		void DeleteCompanyInvoice(CompanyInvoice ci);
		void DeleteCompanyInvoice(int id);
		CompanyInvoice GetCompanyInvoiceById(int id);
		IQueryable<CompanyInvoice> GetAllCompanyInvoices();

		//CompanyInvoiceItem
		void AddCompanyInvoiceItem(CompanyInvoiceItem cii);
		void DeleteCompanyInvoiceItem(CompanyInvoiceItem cii);
		void DeleteCompanyInvoiceItem(int id);
		CompanyInvoiceItem GetCompanyInvoiceItemById(int id);
		IQueryable<CompanyInvoiceItem> GetAllCompanyInvoiceItems();

		//CompanyPayment
		void AddCompanyPayment(CompanyPayment cp);
		void DeleteCompanyPayment(CompanyPayment cp);
		void DeleteCompanyPayment(int id);
		CompanyPayment GetCompanyPaymentById(int id);
		IQueryable<CompanyPayment> GetAllCompanyPayments();

		//VolunteerTimeSot
		void AddVolunteerTimeSlot(VolunteerTimeSlot vts);
		void DeleteVolunteerTimeSlot(VolunteerTimeSlot vts);
		void DeleteVolunteerTimeSlot(int id);
		VolunteerTimeSlot GetVolunteerTimeSlotById(int id);
		IQueryable<VolunteerTimeSlot> GetAllVolunteerTimeSlots();

		//Volunteer
		void AddVolunteer(Volunteer v);
		void DeleteVolunteer(Volunteer v);
		void DeleteVolunteer(int id);
		Volunteer GetVolunteerById(int id);
		IQueryable<Volunteer> GetAllVolunteers();

		//Register volunteers for timeslots
		void RegisterVolunteerForVolunteerTimeSlot(Volunteer v, VolunteerTimeSlot vts);

		void UnRegisterVolunteerForVolunteerTimeSlot(Volunteer v,
													 VolunteerTimeSlot vts);

		//MechManiaTeam
		void AddMechManiaTeam(MechManiaTeam mmt);
		void DeleteMechManiaTeam(MechManiaTeam mmt);
		void DeleteMechManiaTeam(int id);
		MechManiaTeam GetMechManiaTeamById(int id);
		IQueryable<MechManiaTeam> GetAllMechManiaTeams();

		//Page
		void AddPage(Page page);
		void DeletePage(Page page);
		void DeletePage(int id);
		Page GetPageById(int id);
		Page GetPageByTitle(string title);
		IQueryable<Page> GetAllPages();

		//StaffMember
		void AddStaffMember(StaffMember sm);
		void DeleteStaffMember(StaffMember sm);
		void DeleteStaffMember(int id);
		StaffMember GetStaffMemberById(int id);
		IQueryable<StaffMember> GetAllStaffMembers();

		//EventContentLink
		void AddEventContentLink(EventContentLink ecl);
		void DeleteEventContentLink(EventContentLink ecl);
		void DeleteEventContentLink(int id);
		EventContentLink GetEventContentLinkById(int id);
		IQueryable<EventContentLink> GetAllEventContentLinks();

		//People
		People GetPeopleById(int id);
		IQueryable<People> GetAllPeople();

		//VolunteersVolunteerTimeSlot
		VolunteersVolunteerTimeSlot GetVolunteersVolunteerTimeSlotById(int id);
		IQueryable<VolunteersVolunteerTimeSlot> GetAllVolunteersVolunteerTimeSlots();

		//General
		/// <summary>
		/// Causes the repository to commit its changes
		/// </summary>
		void Save();

		void CreateDatabase();
		bool DatabaseExists();
		void DeleteDatabase();

	}
}
