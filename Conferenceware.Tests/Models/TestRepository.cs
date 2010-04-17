using System;
using System.Collections.Generic;
using System.Linq;
using Conferenceware.Models;

namespace Conferenceware.Tests.Models
{
	class TestRepository : IRepository
	{
		/// <summary>
		/// Internal reference max id for a person
		/// </summary>
		private int _personMaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for pages
		/// </summary>
		private List<Page> _pages = new List<Page>();
		private int _pageMaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for event content links
		/// </summary>
		private List<EventContentLink> _eventContentLinks = new List<EventContentLink>();
		private int _eventContentLinkMaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for MechMania Teams
		/// </summary>
		private List<MechManiaTeam> _mechManiaTeams = new List<MechManiaTeam>();
		private int _mechManiaTeamMaxId = 0;

		/// <summary>
		/// Internal storage and reference max id for locations
		/// </summary>
		private List<Location> _locations = new List<Location>();
		private int _locationMaxId = 0;

		/// <summary>
		/// Internal storage for staff members
		/// </summary>
		private List<StaffMember> _staffMembers = new List<StaffMember>();

		/// <summary>
		/// Internal storage for volunteers
		/// </summary>
		private List<Volunteer> _volunteers = new List<Volunteer>();

		/// <summary>
		/// Internal storage and reference max id for company payments
		/// </summary>
		private List<CompanyPayment> _companyPayments = new List<CompanyPayment>();
		private int _companyPaymentsMaxId = 0;

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
		/// Internal storage for a company person.
		/// </summary>
		private List<CompanyPerson> _companyPeople = new List<CompanyPerson>();

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
		/// Internal storage for attendees.
		/// </summary>
		private List<Attendee> _attendees = new List<Attendee>();

		/// <summary>
		/// Internal storage for speakers.
		/// </summary>
		private List<Speaker> _speakers = new List<Speaker>();

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
			if (attendee.People == null)
				attendee.People = new People();

			attendee.People.id = ++_personMaxId;
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
			speaker.People.id = ++_personMaxId;
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
			cp.People.id = ++_personMaxId;
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
			return _companyInvoiceItems.AsQueryable();
		}

		public void AddCompanyPayment(CompanyPayment cp)
		{
			cp.id = ++_companyPaymentsMaxId;
			_companyPayments.Add(cp);
		}

		public void DeleteCompanyPayment(CompanyPayment cp)
		{
			_companyPayments.Remove(cp);
		}

		public void DeleteCompanyPayment(int id)
		{
			DeleteCompanyPayment(GetCompanyPaymentById(id));
		}

		public CompanyPayment GetCompanyPaymentById(int id)
		{
			return _companyPayments.SingleOrDefault(x => id == x.id);
		}

		public IQueryable<CompanyPayment> GetAllCompanyPayments()
		{
			return _companyPayments.AsQueryable();
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
			v.People.id = ++_personMaxId;
			_volunteers.Add(v);
		}

		public void DeleteVolunteer(Volunteer v)
		{
			_volunteers.Remove(v);
		}

		public void DeleteVolunteer(int id)
		{
			DeleteVolunteer(GetVolunteerById(id));
		}

		public Volunteer GetVolunteerById(int id)
		{
			return _volunteers.SingleOrDefault(x => x.People.id == id);
		}

		public IQueryable<Volunteer> GetAllVolunteers()
		{
			return _volunteers.AsQueryable();
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
			mmt.id = ++_mechManiaTeamMaxId;
			_mechManiaTeams.Add(mmt);
		}

		public void DeleteMechManiaTeam(MechManiaTeam mmt)
		{
			_mechManiaTeams.Remove(mmt);
		}

		public void DeleteMechManiaTeam(int id)
		{
			DeleteMechManiaTeam(GetMechManiaTeamById(id));
		}

		public MechManiaTeam GetMechManiaTeamById(int id)
		{
			return _mechManiaTeams.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<MechManiaTeam> GetAllMechManiaTeams()
		{
			return _mechManiaTeams.AsQueryable();
		}

		public void AddPage(Page page)
		{
			page.id = ++_pageMaxId;
			_pages.Add(page);
		}

		public void DeletePage(Page page)
		{
			_pages.Remove(page);
		}

		public void DeletePage(int id)
		{
			DeletePage(GetPageById(id));
		}

		public Page GetPageById(int id)
		{
			return _pages.SingleOrDefault(x => x.id == id);
		}

		public Page GetPageByTitle(string title)
		{
			return _pages.SingleOrDefault(x => x.title.Equals(title));
		}

		public IQueryable<Page> GetAllPages()
		{
			return _pages.AsQueryable();
		}

		public void AddStaffMember(StaffMember sm)
		{
			sm.People.id = ++_personMaxId;
			_staffMembers.Add(sm);
		}

		public void DeleteStaffMember(StaffMember sm)
		{
			_staffMembers.Remove(sm);
		}

		public void DeleteStaffMember(int id)
		{
			DeleteStaffMember(GetStaffMemberById(id));
		}

		public StaffMember GetStaffMemberById(int id)
		{
			return _staffMembers.SingleOrDefault(x => x.People.id == id);
		}

		public IQueryable<StaffMember> GetAllStaffMembers()
		{
			return _staffMembers.AsQueryable();
		}

		public void AddEventContentLink(EventContentLink ecl)
		{
			ecl.id = ++_eventContentLinkMaxId;
			_eventContentLinks.Add(ecl);
		}

		public void DeleteEventContentLink(EventContentLink ecl)
		{
			_eventContentLinks.Remove(ecl);
		}

		public void DeleteEventContentLink(int id)
		{
			DeleteEventContentLink(GetEventContentLinkById(id));
		}

		public EventContentLink GetEventContentLinkById(int id)
		{
			return _eventContentLinks.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<EventContentLink> GetAllEventContentLinks()
		{
			return _eventContentLinks.AsQueryable();
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

		public void CreateDatabase()
		{
			// initialize stuff
			_attendees = new List<Attendee>();
			_companies = new List<Company>();
			_companyInvoiceItems = new List<CompanyInvoiceItem>();
			_companyInvoices = new List<CompanyInvoice>();
			_companyPayments = new List<CompanyPayment>();
			_companyPeople = new List<CompanyPerson>();
			_eventContentLinks = new List<EventContentLink>();
			_events = new List<Event>();
			_foods = new List<Food>();
			_locations = new List<Location>();
			_mechManiaTeams = new List<MechManiaTeam>();
			_pages = new List<Page>();
			_speakers = new List<Speaker>();
			_staffMembers = new List<StaffMember>();
			_timeslots = new List<TimeSlot>();
			_tshirts = new List<TShirtSize>();
			_volunteers = new List<Volunteer>();

			_companyMaxId = 0;
			_companyInvoiceItemsMaxId = 0;
			_companyInvoicesMaxId = 0;
			_companyPaymentsMaxId = 0;
			_eventContentLinkMaxId = 0;
			_eventMaxId = 0;
			_foodMaxId = 0;
			_locationMaxId = 0;
			_mechManiaTeamMaxId = 0;
			_pageMaxId = 0;
			_timeslotMaxId = 0;
			_tshirtsMaxId = 0;
		}

		public bool DatabaseExists()
		{
			return _attendees != null;
		}

		public void DeleteDatabase()
		{
			_attendees = null;
			_companies = null;
			_companyInvoiceItems = null;
			_companyInvoices = null;
			_companyPayments = null;
			_companyPeople = null;
			_eventContentLinks = null;
			_events = null;
			_foods = null;
			_locations = null;
			_mechManiaTeams = null;
			_pages = null;
			_speakers = null;
			_staffMembers = null;
			_timeslots = null;
			_tshirts = null;
			_volunteers = null;
		}
	}
}
