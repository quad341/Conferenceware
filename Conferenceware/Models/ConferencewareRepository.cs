using System.Collections.Generic;
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

		public ConferencewareRepository(string connectionString)
		{
			_conferenceware = new ConferencewareDataContext(connectionString);
		}

		#region IRepository Members

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
			EventsAttendee eva =
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
			EventsAttendee eva =
				_conferenceware.EventsAttendees.SingleOrDefault(
					x => x.Attendee == attendee && x.Event == ev);
			_conferenceware.EventsAttendees.DeleteOnSubmit(eva);
		}

		public void RegisterSpeakerForEvent(Speaker speaker, Event ev)
		{
			EventsSpeaker evs =
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
			EventsSpeaker evs =
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

		public void AddCompany(Company c)
		{
			_conferenceware.Companies.InsertOnSubmit(c);
		}

		public void DeleteCompany(Company c)
		{
			_conferenceware.Companies.DeleteOnSubmit(c);
		}

		public void DeleteCompany(int id)
		{
			_conferenceware.Companies.DeleteOnSubmit(GetCompanyById(id));
		}

		public Company GetCompanyById(int id)
		{
			return _conferenceware.Companies.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<Company> GetAllCompanies()
		{
			return _conferenceware.Companies.AsQueryable();
		}

		public void AddCompanyPerson(CompanyPerson cp)
		{
			_conferenceware.CompanyPersons.InsertOnSubmit(cp);
		}

		public void DeleteCompanyPerson(CompanyPerson cp)
		{
			_conferenceware.CompanyPersons.DeleteOnSubmit(cp);
		}

		public void DeleteCompanyPerson(int id)
		{
			_conferenceware.CompanyPersons.DeleteOnSubmit(GetCompanyPersonById(id));
		}

		public CompanyPerson GetCompanyPersonById(int id)
		{
			return _conferenceware.CompanyPersons.SingleOrDefault(x => x.person_id == id);
		}

		public IQueryable<CompanyPerson> GetAllCompanyPersons()
		{
			return _conferenceware.CompanyPersons.AsQueryable();
		}

		public void AddCompanyInvoice(CompanyInvoice ci)
		{
			_conferenceware.CompanyInvoices.InsertOnSubmit(ci);
		}

		public void DeleteCompanyInvoice(CompanyInvoice ci)
		{
			_conferenceware.CompanyInvoices.DeleteOnSubmit(ci);
		}

		public void DeleteCompanyInvoice(int id)
		{
			_conferenceware.CompanyInvoices.DeleteOnSubmit(GetCompanyInvoiceById(id));
		}

		public CompanyInvoice GetCompanyInvoiceById(int id)
		{
			return _conferenceware.CompanyInvoices.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<CompanyInvoice> GetAllCompanyInvoices()
		{
			return _conferenceware.CompanyInvoices.AsQueryable();
		}

		public void AddCompanyInvoiceItem(CompanyInvoiceItem cii)
		{
			_conferenceware.CompanyInvoiceItems.InsertOnSubmit(cii);
		}

		public void DeleteCompanyInvoiceItem(CompanyInvoiceItem cii)
		{
			_conferenceware.CompanyInvoiceItems.DeleteOnSubmit(cii);
		}

		public void DeleteCompanyInvoiceItem(int id)
		{
			_conferenceware.CompanyInvoiceItems.DeleteOnSubmit(
				GetCompanyInvoiceItemById(id));
		}

		public CompanyInvoiceItem GetCompanyInvoiceItemById(int id)
		{
			return _conferenceware.CompanyInvoiceItems.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<CompanyInvoiceItem> GetAllCompanyInvoiceItems()
		{
			return _conferenceware.CompanyInvoiceItems.AsQueryable();
		}

		public void AddCompanyPayment(CompanyPayment cp)
		{
			_conferenceware.CompanyPayments.InsertOnSubmit(cp);
		}

		public void DeleteCompanyPayment(CompanyPayment cp)
		{
			_conferenceware.CompanyPayments.DeleteOnSubmit(cp);
		}

		public void DeleteCompanyPayment(int id)
		{
			_conferenceware.CompanyPayments.DeleteOnSubmit(GetCompanyPaymentById(id));
		}

		public CompanyPayment GetCompanyPaymentById(int id)
		{
			return _conferenceware.CompanyPayments.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<CompanyPayment> GetAllCompanyPayments()
		{
			return _conferenceware.CompanyPayments.AsQueryable();
		}

		public void AddVolunteerTimeSlot(VolunteerTimeSlot vts)
		{
			_conferenceware.VolunteerTimeSlots.InsertOnSubmit(vts);
		}

		public void DeleteVolunteerTimeSlot(VolunteerTimeSlot vts)
		{
			_conferenceware.VolunteerTimeSlots.DeleteOnSubmit(vts);
		}

		public void DeleteVolunteerTimeSlot(int id)
		{
			_conferenceware.VolunteerTimeSlots.DeleteOnSubmit(GetVolunteerTimeSlotById(id));
		}

		public VolunteerTimeSlot GetVolunteerTimeSlotById(int id)
		{
			return
				_conferenceware.VolunteerTimeSlots.SingleOrDefault(x => x.timeslot_id == id);
		}

		public IQueryable<VolunteerTimeSlot> GetAllVolunteerTimeSlots()
		{
			return _conferenceware.VolunteerTimeSlots.AsQueryable();
		}

		public void AddVolunteer(Volunteer v)
		{
			_conferenceware.Volunteers.InsertOnSubmit(v);
		}

		public void DeleteVolunteer(Volunteer v)
		{
			_conferenceware.Volunteers.DeleteOnSubmit(v);
		}

		public void DeleteVolunteer(int id)
		{
			_conferenceware.Volunteers.DeleteOnSubmit(GetVolunteerById(id));
		}

		public Volunteer GetVolunteerById(int id)
		{
			return _conferenceware.Volunteers.SingleOrDefault(x => x.person_id == id);
		}

		public IQueryable<Volunteer> GetAllVolunteers()
		{
			return _conferenceware.Volunteers.AsQueryable();
		}

		public void RegisterVolunteerForVolunteerTimeSlot(Volunteer v,
														  VolunteerTimeSlot vts)
		{
			if (_conferenceware.VolunteersVolunteerTimeSlots.SingleOrDefault(x =>
																			 x.Volunteer ==
																			 v &&
																			 x.
																				VolunteerTimeSlot ==
																			 vts) == null)
			{
				var vvts = new VolunteersVolunteerTimeSlot
							{
								Volunteer = v,
								VolunteerTimeSlot = vts,
								comment = ""
							};
				_conferenceware.VolunteersVolunteerTimeSlots.InsertOnSubmit(vvts);
			}
		}

		public void UnRegisterVolunteerForVolunteerTimeSlot(Volunteer v,
															VolunteerTimeSlot vts)
		{
			// there appears to be a weird race condition here where if someone times it just right
			// or is editted just right, they can actually get registered for something twice
			// that would cause this to blow up if we look for SingleOrDefault
			IEnumerable<VolunteersVolunteerTimeSlot> vvtss =
				_conferenceware.VolunteersVolunteerTimeSlots.Where(
					x => x.Volunteer == v && x.VolunteerTimeSlot == vts);
			_conferenceware.VolunteersVolunteerTimeSlots.DeleteAllOnSubmit(vvtss);
		}

		public void AddMechManiaTeam(MechManiaTeam mmt)
		{
			_conferenceware.MechManiaTeams.InsertOnSubmit(mmt);
		}

		public void DeleteMechManiaTeam(MechManiaTeam mmt)
		{
			_conferenceware.MechManiaTeams.DeleteOnSubmit(mmt);
		}

		public void DeleteMechManiaTeam(int id)
		{
			_conferenceware.MechManiaTeams.DeleteOnSubmit(GetMechManiaTeamById(id));
		}

		public MechManiaTeam GetMechManiaTeamById(int id)
		{
			return _conferenceware.MechManiaTeams.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<MechManiaTeam> GetAllMechManiaTeams()
		{
			return _conferenceware.MechManiaTeams.AsQueryable();
		}

		public void AddPage(Page page)
		{
			_conferenceware.Pages.InsertOnSubmit(page);
		}

		public void DeletePage(Page page)
		{
			_conferenceware.Pages.DeleteOnSubmit(page);
		}

		public void DeletePage(int id)
		{
			_conferenceware.Pages.DeleteOnSubmit(GetPageById(id));
		}

		public Page GetPageById(int id)
		{
			return _conferenceware.Pages.SingleOrDefault(x => x.id == id);
		}

		public Page GetPageByTitle(string title)
		{
			return _conferenceware.Pages.SingleOrDefault(x => x.title == title);
		}

		public IQueryable<Page> GetAllPages()
		{
			return _conferenceware.Pages.AsQueryable();
		}

		public void AddStaffMember(StaffMember sm)
		{
			_conferenceware.StaffMembers.InsertOnSubmit(sm);
		}

		public void DeleteStaffMember(StaffMember sm)
		{
			_conferenceware.StaffMembers.DeleteOnSubmit(sm);
		}

		public void DeleteStaffMember(int id)
		{
			_conferenceware.StaffMembers.DeleteOnSubmit(GetStaffMemberById(id));
		}

		public StaffMember GetStaffMemberById(int id)
		{
			return _conferenceware.StaffMembers.SingleOrDefault(x => x.person_id == id);
		}

		public IQueryable<StaffMember> GetAllStaffMembers()
		{
			return _conferenceware.StaffMembers.AsQueryable();
		}

		public void AddEventContentLink(EventContentLink ecl)
		{
			_conferenceware.EventContentLinks.InsertOnSubmit(ecl);
		}

		public void DeleteEventContentLink(EventContentLink ecl)
		{
			_conferenceware.EventContentLinks.DeleteOnSubmit(ecl);
		}

		public void DeleteEventContentLink(int id)
		{
			_conferenceware.EventContentLinks.DeleteOnSubmit(GetEventContentLinkById(id));
		}

		public EventContentLink GetEventContentLinkById(int id)
		{
			return _conferenceware.EventContentLinks.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<EventContentLink> GetAllEventContentLinks()
		{
			return _conferenceware.EventContentLinks.AsQueryable();
		}

		public People GetPeopleById(int id)
		{
			return _conferenceware.Peoples.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<People> GetAllPeople()
		{
			return _conferenceware.Peoples.AsQueryable();
		}

		public VolunteersVolunteerTimeSlot GetVolunteersVolunteerTimeSlotById(int id)
		{
			return
				_conferenceware.VolunteersVolunteerTimeSlots.SingleOrDefault(x => x.id == id);
		}

		public IQueryable<VolunteersVolunteerTimeSlot>
			GetAllVolunteersVolunteerTimeSlots()
		{
			return _conferenceware.VolunteersVolunteerTimeSlots.AsQueryable();
		}

		public void Save()
		{
			_conferenceware.SubmitChanges();
		}

		public void CreateDatabase()
		{
			_conferenceware.CreateDatabase();
		}

		public bool DatabaseExists()
		{
			return _conferenceware.DatabaseExists();
		}

		public void DeleteDatabase()
		{
			_conferenceware.DeleteDatabase();
		}

		#endregion

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
	}
}