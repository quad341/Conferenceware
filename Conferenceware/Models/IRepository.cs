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
		/// <returns>A valid Food ID.</returns>
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
		/// <param name="id">A valid TShirtSize ID.</param>
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
		/// <param name="id">A valid Company ID.</param>
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
		/// <param name="id">A valid CompanyPerson ID.</param>
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

		/// <summary>
		/// Adds a CompanyInvoice item to the repository.
		/// Precondition: ci must have a valid ID.
		/// Postcondition: The CompanyInvoice item is contained in the repository.
		/// </summary>
		/// <param name="ci">A CompanyInvoice object with a valid ID from the repository</param>
		void AddCompanyInvoice(CompanyInvoice ci);

		/// <summary>
		/// Deletes a CompanyInvoice item from the repository.
		/// Precondition: ci must have a valid ID from the repository.
		/// Postcondition: The repository no longer contains that CompanyInvoice object.
		/// </summary>
		/// <param name="ci">A CompanyInvoice object with a valid ID from the repository</param>
		void DeleteCompanyInvoice(CompanyInvoice ci);

		/// <summary>
		/// Delete a CompanyInvoice item from the repository.
		/// Precondition: id is a valid CompanyInvoice ID.
		/// Postcondition: The repository no longer contains a CompanyInvoice item with that ID.
		/// </summary>
		/// <param name="id">A valid CompanyInvoice ID.</param>
		void DeleteCompanyInvoice(int id);

		/// <summary>
		/// Retrieve a CompanyInvoice object.
		/// Precondition: id is a valid CompanyInvoice ID.
		/// </summary>
		/// <param name="id">A valid CompanyInvoice ID from the repository.</param>
		/// <returns>A CompanyInvoice object with data from the repository.</returns>
		CompanyInvoice GetCompanyInvoiceById(int id);

		/// <summary>
		/// Get all CompanyInvoice objects from the repository.
		/// </summary>
		/// <returns>A List object containing all CompanyInvoice objects from the data repository.</returns>
		IQueryable<CompanyInvoice> GetAllCompanyInvoices();

		//CompanyInvoiceItem
		/// <summary>
		/// Adds a company invoice item
		/// </summary>
		/// <param name="cii">The item to add</param>
		void AddCompanyInvoiceItem(CompanyInvoiceItem cii);
		/// <summary>
		/// Delete a company invoice item
		/// </summary>
		/// <param name="cii">The item to delete</param>
		void DeleteCompanyInvoiceItem(CompanyInvoiceItem cii);
		/// <summary>
		/// Delete a company invoice item
		/// </summary>
		/// <param name="id">The id of the item to delete</param>
		void DeleteCompanyInvoiceItem(int id);
		/// <summary>
		/// Gets a company invoice item with the given id or null
		/// </summary>
		/// <param name="id">The id to search for</param>
		/// <returns>The company invoice item with the given id or null</returns>
		CompanyInvoiceItem GetCompanyInvoiceItemById(int id);
		/// <summary>
		/// Gets all the company invoice items
		/// </summary>
		/// <returns>All of the company invoice items</returns>
		IQueryable<CompanyInvoiceItem> GetAllCompanyInvoiceItems();

		//CompanyPayment
		/// <summary>
		/// Adds a company payment
		/// </summary>
		/// <param name="cp">The payment to add</param>
		void AddCompanyPayment(CompanyPayment cp);
		/// <summary>
		/// Deletes a company payment
		/// </summary>
		/// <param name="cp">The payment to delete</param>
		void DeleteCompanyPayment(CompanyPayment cp);
		/// <summary>
		/// Delete a company payment
		/// </summary>
		/// <param name="id">The id of the company payment to delete</param>
		void DeleteCompanyPayment(int id);
		/// <summary>
		/// Gets a specified company payment or null if the id isn't found
		/// </summary>
		/// <param name="id">The id of a company payment to retrieve</param>
		/// <returns>The company payment or null</returns>
		CompanyPayment GetCompanyPaymentById(int id);
		/// <summary>
		/// Gets all company payments
		/// </summary>
		/// <returns>All of the company payments</returns>
		IQueryable<CompanyPayment> GetAllCompanyPayments();

		//VolunteerTimeSot
		/// <summary>
		/// Adds a volunteer time slot
		/// </summary>
		/// <param name="vts">The volunteer time slot to add</param>
		void AddVolunteerTimeSlot(VolunteerTimeSlot vts);
		/// <summary>
		/// Deletes a volunteer time slot
		/// </summary>
		/// <param name="vts">The volunteer time slot to delete</param>
		void DeleteVolunteerTimeSlot(VolunteerTimeSlot vts);
		/// <summary>
		/// Deletes a volunteer time slot
		/// </summary>
		/// <param name="id">The id of the volunteer time slot to delete</param>
		void DeleteVolunteerTimeSlot(int id);
		/// <summary>
		/// Gets a specified volunteer time slot or null if it is not found
		/// </summary>
		/// <param name="id">The id of the volunteer time slot to find</param>
		/// <returns>The time slot with the specified id or null</returns>
		VolunteerTimeSlot GetVolunteerTimeSlotById(int id);
		/// <summary>
		/// Gets all the volunteer time slots
		/// </summary>
		/// <returns>All the volunteer time slots</returns>
		IQueryable<VolunteerTimeSlot> GetAllVolunteerTimeSlots();

		//Volunteer
		/// <summary>
		/// Adds a volunteer
		/// </summary>
		/// <param name="v">The volunteer to add</param>
		void AddVolunteer(Volunteer v);
		/// <summary>
		/// Deletes a volunteer
		/// </summary>
		/// <param name="v">The volunteer to delete</param>
		void DeleteVolunteer(Volunteer v);
		/// <summary>
		/// Deletes a volunteer
		/// </summary>
		/// <param name="id">The id of the volunteer to delete</param>
		void DeleteVolunteer(int id);
		/// <summary>
		/// Gets the volunteer with the specified id or null if not found
		/// </summary>
		/// <param name="id">The id of the volunteer to select</param>
		/// <returns>The volunteer with the given id or null</returns>
		Volunteer GetVolunteerById(int id);
		/// <summary>
		/// Gets all the volunteers
		/// </summary>
		/// <returns>All the volunteers</returns>
		IQueryable<Volunteer> GetAllVolunteers();

		//Register volunteers for timeslots
		/// <summary>
		/// Registers a volunteer for a volunteer time slot
		/// </summary>
		/// <param name="v">The volunteer to register</param>
		/// <param name="vts">The volunteer time slot to register the volunteer to</param>
		void RegisterVolunteerForVolunteerTimeSlot(Volunteer v, VolunteerTimeSlot vts);

		/// <summary>
		/// Removes the registration for a volunteer to a timeslot
		/// </summary>
		/// <param name="v">The volunteer to unregister</param>
		/// <param name="vts">The volunteer time slot to disconnect</param>
		void UnRegisterVolunteerForVolunteerTimeSlot(Volunteer v,
													 VolunteerTimeSlot vts);

		//MechManiaTeam
		/// <summary>
		/// Adds a mechmania team
		/// </summary>
		/// <param name="mmt">The mechmania team to add</param>
		void AddMechManiaTeam(MechManiaTeam mmt);
		/// <summary>
		/// Deletes a mechmania team
		/// </summary>
		/// <param name="mmt">The mechmania team to delete</param>
		void DeleteMechManiaTeam(MechManiaTeam mmt);
		/// <summary>
		/// Deletes a mechmania team
		/// </summary>
		/// <param name="id">The id of the mechmania team to delete</param>
		void DeleteMechManiaTeam(int id);
		/// <summary>
		/// Gets a specified mechmania team with the given id or null if not found
		/// </summary>
		/// <param name="id">The id of the team to find</param>
		/// <returns>The specified mechmania team or null</returns>
		MechManiaTeam GetMechManiaTeamById(int id);
		/// <summary>
		/// Gets all the mechmania teams
		/// </summary>
		/// <returns>All the mechmania teams</returns>
		IQueryable<MechManiaTeam> GetAllMechManiaTeams();

		//Page
		/// <summary>
		/// Adds a page
		/// </summary>
		/// <param name="page">The page to add</param>
		void AddPage(Page page);
		/// <summary>
		/// Deletes a page
		/// </summary>
		/// <param name="page">The page to delete</param>
		void DeletePage(Page page);
		/// <summary>
		/// Deletes a page
		/// </summary>
		/// <param name="id">The id of the page to delete</param>
		void DeletePage(int id);
		/// <summary>
		/// Gets a page with the specified id or null if not found
		/// </summary>
		/// <param name="id">The id of the page to select</param>
		/// <returns>The page or null</returns>
		Page GetPageById(int id);
		/// <summary>
		/// Gets a page with the specified title or null if not found
		/// </summary>
		/// <param name="title">The title of the page to find</param>
		/// <returns>The specified page or null</returns>
		Page GetPageByTitle(string title);
		/// <summary>
		/// Gets all the pages
		/// </summary>
		/// <returns>All the pages</returns>
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
