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
				RedirectToAction("Index");
			}
			return View("Index");
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
				message.Bcc.Add(new MailAddress(person.name));
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
							Attendees = _repository.GetAllAttendees(),
							CompanyPersons = _repository.GetAllCompanyPersons(),
							MechManiaTeams = _repository.GetAllMechManiaTeams(),
							Speakers = _repository.GetAllSpeakers(),
							StaffMembers = _repository.GetAllStaffMembers(),
							Volunteers = _repository.GetAllVolunteers()
						};
			return baseData;
		}

	}
}
