using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	public class SpeakerController : Controller
	{
		private readonly IRepository _repository;

		public SpeakerController()
			: this(new ConferencewareRepository())
		{
			// nothing else to do
		}

		public SpeakerController(IRepository repo)
		{
			_repository = repo;
		}

		//
		// GET: /Speaker/

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllSpeakers());
		}

		//
		// GET: /Speaker/Create

		public ActionResult Create()
		{
			return View("Create", new Speaker());
		}

		//
		// POST: /Speaker/Create

		[HttpPost]
		public ActionResult Create(Speaker speakerToCreate)
		{
			if (ModelState.IsValid)
			{
				_repository.AddSpeaker(speakerToCreate);
				_repository.Save();

				return RedirectToAction("Index");
			}
			return View("Create", speakerToCreate);
		}

		//
		// GET: /Speaker/Edit/5

		public ActionResult Edit(int id)
		{
			var speaker = _repository.GetSpeakerById(id);
			if (speaker == null)
			{
				return View("SpeakerNotFound");
			}
			return View("Edit", speaker);
		}

		//
		// POST: /Speaker/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var speaker = _repository.GetSpeakerById(id);
			if (speaker == null)
			{
				return View("SpeakerNotFound");
			}
			if (ModelState.IsValid)
			{
				speaker.People.name = collection["People.name"];
				speaker.People.email = collection["People.email"];
				speaker.People.phone_number = collection["People.phone_number"];
				_repository.Save();

				return RedirectToAction("Index");
			}
			return View("Edit", speaker);
		}

		public ActionResult Delete(int id)
		{
			var speaker = _repository.GetSpeakerById(id);
			if (speaker == null)
			{
				return View("SpeakerNotFound");
			}
			try
			{
				_repository.DeleteSpeaker(speaker);
				TempData["Message"] = speaker.People.name + " was deleted";
				_repository.Save();
			}
			catch
			{
				TempData["Message"] = "Cannot delete item. Remove all references";
			}
			return RedirectToAction("Index");
		}
	}
}
