using System;
using System.Collections.Generic;
using System.Linq;
using Conferenceware.Models;

namespace Conferenceware.Tests.Models
{
	class TestRepository : IRepository
	{
		/// <summary>
        /// Internal storage and reference max id for locations
		/// </summary>
		private List<Location> _locations = new List<Location>();
        private int _locationMaxId = 0;

        /// <summary>
        /// Internal storage and reference max id for locations
        /// </summary>
        private List<TShirtSize> _tshirts = new List<TShirtSize>();
        private int _tshirtsMaxId = 0;

        /// <summary>
        /// Internal storage and reference max id for timeslots.
        /// </summary>
        private List<TimeSlot> _timeslots = new List<TimeSlot>();
        private int _timeslotMaxId = 0;

        /// <summary>
        /// Internal storage and reference max id for companies.
        /// </summary>
        private List<Company> _companies = new List<Company>();
        private int _companyMaxId = 0;

        /// <summary>
        /// Internal storage and reference max id for company person.
        /// </summary>
        private List<CompanyPerson> _companyPeople = new List<CompanyPerson>();
        private int _companyPeopleMaxId = 0;

        /// <summary>
        /// Internal storage and reference max id for company invoices.
        /// </summary>
        private List<CompanyInvoice> _companyInvoices = new List<CompanyInvoice>();
        private int _companyInvoicesMaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for company invoice items.
		/// </summary>
        private List<CompanyInvoiceItem> _companyInvoiceItems = new List<CompanyInvoiceItem>();
        private int _companyInvoiceItemsMaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for events.
		/// </summary>
		private List<Event> _events = new List<Event>();
		private int _eventMaxId = 0;

        /// <summary>
        /// Internal storage and reference max id for foods.
        /// </summary>
        private List<Food> _foods = new List<Food>();
        private int _foodMaxId = 0;

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
			return _events.SingleOrDefault(x => x.id == id);
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
			timeslot.id = ++_timeslotMaxId;
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

		public void UnRegisterAttendeeForEvent(Attendee attendee, Event ev)
		{
			throw new NotImplementedException();
		}

		public void RegisterSpeakerForEvent(Speaker speaker, Event ev)
		{
			var evs = new EventsSpeaker();
			evs.Speaker = speaker;
			evs.Event = ev;
			ev.EventsSpeakers.Insert(0, evs);
			speaker.EventsSpeakers.Insert(0, evs);
		}

		public void UnRegisterSpeakerForEvent(Speaker speaker, Event ev)
		{
			throw new NotImplementedException();
		}

		public void AddFood(Food food)
		{
		    food.id = ++_foodMaxId;
			_foods.Add(food);
		}

		public void DeleteFood(Food food)
		{
		    _foods.Remove(food);
		}

	    public void DeleteFood(int id)
		{
			DeleteFood(GetFoodById(id));
		}

		public Food GetFoodById(int id)
		{
            return _foods.SingleOrDefault(x => id == x.id);
		}

		public IQueryable<Food> GetAllFoods()
		{
		    return _foods.AsQueryable();
		}

		public void AddTShirtSize(TShirtSize t)
		{
		    t.id = ++_tshirtsMaxId;
			_tshirts.Add(t);
		}

		public void DeleteTShirtSize(TShirtSize tshirtsize)
		{
		    _tshirts.Remove(tshirtsize);
		}

		public void DeleteTShirtSize(int id)
		{
			DeleteTShirtSize(GetTShirtSizeById(id));
		}

		public TShirtSize GetTShirtSizeById(int id)
		{
            return _tshirts.SingleOrDefault(x => id == x.id);
		}

		public IQueryable<TShirtSize> GetAllTShirtSizes()
		{
		    return _tshirts.AsQueryable();
		}

		public void AddCompany(Company c)
		{
		    c.id = ++_companyMaxId;
		    _companies.Add(c);
		}

		public void DeleteCompany(Company c)
		{
		    _companies.Remove(c);
		}

		public void DeleteCompany(int id)
		{
		    DeleteCompany(GetCompanyById(id));
		}

		public Company GetCompanyById(int id)
		{
            return _companies.SingleOrDefault(x => id == x.id);
		}

		public IQueryable<Company> GetAllCompanies()
		{
		    return _companies.AsQueryable();
		}

		public void AddCompanyPerson(CompanyPerson cp)
		{
		    cp.People.id = ++_companyPeopleMaxId;
            _companyPeople.Add(cp);
		}

		public void DeleteCompanyPerson(CompanyPerson cp)
		{
		    _companyPeople.Remove(cp);
		}

		public void DeleteCompanyPerson(int id)
		{
		    DeleteCompanyPerson(GetCompanyPersonById(id));
		}

		public CompanyPerson GetCompanyPersonById(int id)
		{
            return _companyPeople.SingleOrDefault(x => x.People.id == id);
		}

		public IQueryable<CompanyPerson> GetAllCompanyPersons()
		{
		    return _companyPeople.AsQueryable();
		}

		public void AddCompanyInvoice(CompanyInvoice ci)
		{
		    ci.id = ++_companyInvoicesMaxId;
		    _companyInvoices.Add(ci);
		}

		public void DeleteCompanyInvoice(CompanyInvoice ci)
		{
		    _companyInvoices.Remove(ci);
		}

		public void DeleteCompanyInvoice(int id)
		{
			DeleteCompanyInvoice(GetCompanyInvoiceById(id));
		}

		public CompanyInvoice GetCompanyInvoiceById(int id)
		{
            return _companyInvoices.SingleOrDefault(x => id == x.id);
		}

		public IQueryable<CompanyInvoice> GetAllCompanyInvoices()
		{
		    return _companyInvoices.AsQueryable();
		}

		public void AddCompanyInvoiceItem(CompanyInvoiceItem cii)
		{
		    cii.id = ++_companyInvoiceItemsMaxId;
            _companyInvoiceItems.Add(cii);
		}

		public void DeleteCompanyInvoiceItem(CompanyInvoiceItem cii)
		{
		    _companyInvoiceItems.Remove(cii);
		}

		public void DeleteCompanyInvoiceItem(int id)
		{
			DeleteCompanyInvoiceItem(GetCompanyInvoiceItemById(id));
		}

		public CompanyInvoiceItem GetCompanyInvoiceItemById(int id)
		{
            return _companyInvoiceItems.SingleOrDefault(x => id == x.id);
		}

		public IQueryable<CompanyInvoiceItem> GetAllCompanyInvoiceItems()
		{
		    _companyInvoiceItems.AsQueryable();
		}

		public void AddCompanyPayment(CompanyPayment cp)
		{
			throw new NotImplementedException();
		}

		public void DeleteCompanyPayment(CompanyPayment cp)
		{
			throw new NotImplementedException();
		}

		public void DeleteCompanyPayment(int id)
		{
			throw new NotImplementedException();
		}

		public CompanyPayment GetCompanyPaymentById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<CompanyPayment> GetAllCompanyPayments()
		{
			throw new NotImplementedException();
		}

		public void AddVolunteerTimeSlot(VolunteerTimeSlot vts)
		{
			throw new NotImplementedException();
		}

		public void DeleteVolunteerTimeSlot(VolunteerTimeSlot vts)
		{
			throw new NotImplementedException();
		}

		public void DeleteVolunteerTimeSlot(int id)
		{
			throw new NotImplementedException();
		}

		public VolunteerTimeSlot GetVolunteerTimeSlotById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<VolunteerTimeSlot> GetAllVolunteerTimeSlots()
		{
			throw new NotImplementedException();
		}

		public void AddVolunteer(Volunteer v)
		{
			throw new NotImplementedException();
		}

		public void DeleteVolunteer(Volunteer v)
		{
			throw new NotImplementedException();
		}

		public void DeleteVolunteer(int id)
		{
			throw new NotImplementedException();
		}

		public Volunteer GetVolunteerById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Volunteer> GetAllVolunteers()
		{
			throw new NotImplementedException();
		}

		public void RegisterVolunteerForVolunteerTimeSlot(Volunteer v, VolunteerTimeSlot vts)
		{
			throw new NotImplementedException();
		}

		public void UnRegisterVolunteerForVolunteerTimeSlot(Volunteer v, VolunteerTimeSlot vts)
		{
			throw new NotImplementedException();
		}

		public void AddMechManiaTeam(MechManiaTeam mmt)
		{
			throw new NotImplementedException();
		}

		public void DeleteMechManiaTeam(MechManiaTeam mmt)
		{
			throw new NotImplementedException();
		}

		public void DeleteMechManiaTeam(int id)
		{
			throw new NotImplementedException();
		}

		public MechManiaTeam GetMechManiaTeamById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<MechManiaTeam> GetAllMechManiaTeams()
		{
			throw new NotImplementedException();
		}

		public void AddPage(Page page)
		{
			throw new NotImplementedException();
		}

		public void DeletePage(Page page)
		{
			throw new NotImplementedException();
		}

		public void DeletePage(int id)
		{
			throw new NotImplementedException();
		}

		public Page GetPageById(int id)
		{
			throw new NotImplementedException();
		}

		public Page GetPageByTitle(string title)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Page> GetAllPages()
		{
			throw new NotImplementedException();
		}

		public void AddStaffMember(StaffMember sm)
		{
			throw new NotImplementedException();
		}

		public void DeleteStaffMember(StaffMember sm)
		{
			throw new NotImplementedException();
		}

		public void DeleteStaffMember(int id)
		{
			throw new NotImplementedException();
		}

		public StaffMember GetStaffMemberById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<StaffMember> GetAllStaffMembers()
		{
			throw new NotImplementedException();
		}

		public void AddEventContentLink(EventContentLink ecl)
		{
			throw new NotImplementedException();
		}

		public void DeleteEventContentLink(EventContentLink ecl)
		{
			throw new NotImplementedException();
		}

		public void DeleteEventContentLink(int id)
		{
			throw new NotImplementedException();
		}

		public EventContentLink GetEventContentLinkById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<EventContentLink> GetAllEventContentLinks()
		{
			throw new NotImplementedException();
		}

		public People GetPeopleById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<People> GetAllPeople()
		{
			throw new NotImplementedException();
		}

		public VolunteersVolunteerTimeSlot GetVolunteersVolunteerTimeSlotById(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<VolunteersVolunteerTimeSlot> GetAllVolunteersVolunteerTimeSlots()
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
