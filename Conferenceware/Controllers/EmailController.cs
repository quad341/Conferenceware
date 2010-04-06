using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Conferenceware.Models;
using Conferenceware.Utils;

namespace Conferenceware.Controllers
{
	public class EmailController : Controller
	{
		private readonly IRepository _repository;

		public EmailController()
			: this(new ConferencewareRepository())
		{
			// done
		}

		public EmailController(IRepository repository)
		{
			_repository = repository;
		}
		//
		// GET: /Email/

		public ActionResult Index()
		{
			return View("Index", AddEveryoneToEmailEditData(new EmailEditData()));
		}

		[HttpPost]
		public ActionResult Index(EmailEditData eed)
		{
			if (eed.SelectedPeopleIds.Length < 1)
			{
				ModelState.AddModelError("SelectedPeopleIds", "At least one recipiant must be selected");
			}
			if (ModelState.IsValid)
			{
				var sd = SettingsData.FromCurrent(
					SettingsData.RESOURCE_FILE_NAME, SettingsData.RESOURCE_FILE_DIR);
				if (eed.SendIndividualEmails)
				{
					SendIndividualEmails(eed, sd);
				}
				else
				{
					SendBccEmail(eed, sd);
				}
				TempData["Message"] = "Emails sent";
				return RedirectToAction("Index");
			}
			return View("Index", AddEveryoneToEmailEditData(eed));
		}

		private void SendBccEmail(EmailEditData eed, SettingsData sd)
		{
			var message = new MailMessage
							{
								From = new MailAddress(sd.EmailFrom),
								Subject = eed.Subject,
								Body = eed.Message
							};
			foreach (var i in eed.SelectedPeopleIds)
			{
				var person = _repository.GetPeopleById(i);
				if (person == null)
				{
					continue;
				}
				message.Bcc.Add(new MailAddress(person.email));
			}
			Mailer.Send(message);
		}

		private void SendIndividualEmails(EmailEditData eed, SettingsData sd)
		{
			foreach (var i in eed.SelectedPeopleIds)
			{
				var person = _repository.GetPeopleById(i);
				if (person == null)
				{
					continue;
				}
				var message = new MailMessage(sd.EmailFrom, person.email)
								{
									Subject = eed.Subject,
									Body =
										Regex.Replace(eed.Message, @"{\s*name\s*}", person.name)
								};
				Mailer.Send(message);
			}
		}

		private EmailEditData AddEveryoneToEmailEditData(EmailEditData baseData)
		{
			baseData.SelectedPeopleIds = baseData.SelectedPeopleIds ?? new int[0];
			baseData.Everyone = new EveryoneCollection
									{
										Attendees =
											_repository.GetAllAttendees().OrderBy(
												x => x.People.name),
										CompanyPersons =
											_repository.GetAllCompanyPersons().OrderBy(
												x => x.Company.name),
										MechManiaTeams = _repository.GetAllMechManiaTeams(),
										Speakers =
											_repository.GetAllSpeakers().OrderBy(
												x => x.People.name),
										StaffMembers =
											_repository.GetAllStaffMembers().OrderBy(
												x => x.People.name),
										Volunteers =
											_repository.GetAllVolunteers().OrderBy(
												x => x.People.name)
									};
			return baseData;
		}

	}
}
