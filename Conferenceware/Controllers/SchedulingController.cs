using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class SchedulingController : Controller
	{
		private readonly IRepository _repository;

		public SchedulingController()
			: this(new ConferencewareRepository())
		{
			// nothing to do
		}

		public SchedulingController(IRepository repo)
		{
			_repository = repo;
		}

		//
		// GET: /Scheduling/

		public ActionResult Index()
		{
			return View("Index");
		}

		public ActionResult EmailScheduleToVolunteers()
		{
			// TODO Implement
			return View("EmailScheduleToVolunteers");
		}

		public ActionResult PreviewRegularEmail()
		{
			var vol =
				_repository.GetAllVolunteers().Where(x => x.NeedsVideoTraining == false).
					SingleOrDefault();
			var message = "";
			if (vol == null)
			{
				TempData["Message"] = "No regular volunteers found";//TODO: localize
			}
			else
			{
				message = GetRegularMessageForVolunteer(vol);
			}
			return View("PreviewEmail", message);
		}

		public ActionResult PreviewVideoEmail()
		{
			var vol =
				_repository.GetAllVolunteers().Where(x => x.NeedsVideoTraining).
					SingleOrDefault();
			var message = "";
			if (vol == null)
			{
				TempData["Message"] = "No video volunteers found";//TODO: localize
			}
			else
			{
				message = GetVideoMessageForVolunteer(vol);
			}
			return View("PreviewEmail", message);
		}
		//TODO: make scheduling interface for volunteers and events

		private String GetMessageForVolunteer(Volunteer vol)
		{
			if (vol.NeedsVideoTraining)
			{
				return GetVideoMessageForVolunteer(vol);
			}
			return GetRegularMessageForVolunteer(vol);
		}
		private string GetRegularMessageForVolunteer(Volunteer vol)
		{
			var sd = SettingsData.Default;
			var message =
				new StringBuilder(String.Format(sd.VolunteerScheduleEmailOpening,
				                                vol.People.name,
				                                "Regular")); //TODO: localize
			message.AppendLine();
			foreach (var vvts in vol.VolunteersVolunteerTimeSlots.Where(x => x.is_confirmed))
			{
				var vts = vvts.VolunteerTimeSlot;
				message.AppendFormat(sd.VolunteerScheduleEmailRegularTimeSlotFormatString,
				                     vts.TimeSlot.start_time.ToString("D"),
				                     vts.TimeSlot.start_time.ToString("t"),
				                     vts.TimeSlot.end_time.ToString("t"),
				                     vvts.comment);
				message.AppendLine();
			}
			message.Append(sd.VolunteerScheduleEmailClosing);
			return message.ToString();
		}

		private string GetVideoMessageForVolunteer(Volunteer vol)
		{
			var sd = SettingsData.Default;
			var message =
				new StringBuilder(String.Format(sd.VolunteerScheduleEmailOpening,
												vol.People.name,
												"Video")); //TODO: localize
			message.AppendLine();
			foreach (var vvts in vol.VolunteersVolunteerTimeSlots.Where(x => x.is_confirmed))
			{
				var vts = vvts.VolunteerTimeSlot;
				var format = vts.is_video
				             	? sd.VolunteerScheduleEmailVideoTimeSlotFormatString
				             	: sd.VolunteerScheduleEmailRegularTimeSlotFormatString;
				message.AppendFormat(format,
									 vts.TimeSlot.start_time.ToString("D"),
									 vts.TimeSlot.start_time.ToString("t"),
									 vts.TimeSlot.end_time.ToString("t"),
									 vvts.comment);
				message.AppendLine();
			}
			message.AppendLine(
				sd.VolunteerScheduleEmailExtraInformationForVideoVolunteers);
			message.Append(sd.VolunteerScheduleEmailClosing);
			return message.ToString();
		}
	}

}
