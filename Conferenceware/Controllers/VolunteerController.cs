using System.Linq;
using System.Web.Mvc;
using Conferenceware.Models;

namespace Conferenceware.Controllers
{
	[Authorize]
	public class VolunteerController : Controller
	{
		private readonly IRepository _repository;

		public VolunteerController()
			: this(new ConferencewareRepository())
		{
			// all good
		}

		public VolunteerController(IRepository repository)
		{
			_repository = repository;
		}

		//
		// GET: /Volunteer/

		public ActionResult Index()
		{
			return View("Index", _repository.GetAllVolunteers());
		}

		//
		// GET: /Volunteer/Create

		public ActionResult Create()
		{
			return View("Create",
						CreateEditDataFromVolunteer(new Volunteer(), _repository));
		}

		//
		// POST: /Volunteer/Create

		[HttpPost]
		public ActionResult Create(VolunteerEditData ved)
		{
			if (ModelState.IsValid)
			{
				_repository.AddVolunteer(ved.Volunteer);
				_repository.Save();
				foreach (int i in ved.ChosenTimeSlots)
				{
					VolunteerTimeSlot vts = _repository.GetVolunteerTimeSlotById(i);
					if (vts != null)
					{
						_repository.RegisterVolunteerForVolunteerTimeSlot(ved.Volunteer, vts);
					}
				}
				_repository.Save();
				return RedirectToAction("Index");
			}
			ved.VolunteerTimeSlots = _repository.GetAllVolunteerTimeSlots();
			return View("Create", ved);
		}

		//
		// GET: /Volunteer/Edit/5

		public ActionResult Edit(int id)
		{
			Volunteer vol = _repository.GetVolunteerById(id);
			if (vol == null)
			{
				return View("VolunteerNotFound");
			}
			return View("Edit", CreateEditDataFromVolunteer(vol, _repository));
		}

		//
		// POST: /Volunteer/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var ved = new VolunteerEditData();
			Volunteer vol = _repository.GetVolunteerById(id);
			if (vol == null)
			{
				return View("VolunteerNotFound");
			}
			ved.Volunteer = vol;
			// This will try to update all the fields in the model based on the form collection
			if (TryUpdateModel(ved, collection))
			{
				IQueryable<VolunteerTimeSlot> oldTimeSlots =
					vol.VolunteersVolunteerTimeSlots.Select(x => x.VolunteerTimeSlot).
						AsQueryable();
				foreach (VolunteerTimeSlot vts in oldTimeSlots)
				{
					_repository.UnRegisterVolunteerForVolunteerTimeSlot(vol, vts);
				}
				_repository.Save();
				foreach (int i in ved.ChosenTimeSlots)
				{
					VolunteerTimeSlot vts = _repository.GetVolunteerTimeSlotById(i);
					if (vts != null)
					{
						_repository.RegisterVolunteerForVolunteerTimeSlot(ved.Volunteer, vts);
					}
				}
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View("Edit", CreateEditDataFromVolunteer(vol, _repository));
		}

		//
		// GET: /Volunteer/Delete/5

		public ActionResult Delete(int id)
		{
			Volunteer vol = _repository.GetVolunteerById(id);
			if (vol == null)
			{
				return View("VolunteerNotFound");
			}
			IQueryable<VolunteerTimeSlot> oldTimeSlots =
				vol.VolunteersVolunteerTimeSlots.Select(x => x.VolunteerTimeSlot).
					AsQueryable();
			foreach (VolunteerTimeSlot vts in oldTimeSlots)
			{
				_repository.UnRegisterVolunteerForVolunteerTimeSlot(vol, vts);
			}
			_repository.DeleteVolunteer(vol);
			_repository.Save();
			TempData["Message"] = "Volunteer deleted";
			return RedirectToAction("Index");
		}

		public static VolunteerEditData CreateEditDataFromVolunteer(
			Volunteer volunteer, IRepository repo)
		{
			var ved = new VolunteerEditData
						{
							Volunteer = volunteer,
							VolunteerTimeSlots = repo.GetAllVolunteerTimeSlots(),
							ChosenTimeSlots =
								new int[volunteer.VolunteersVolunteerTimeSlots.Count],
							Foods = new SelectList(repo.GetAllFoods(), "id", "name"),
							TShirtSizes =
								new SelectList(repo.GetAllTShirtSizes(), "id", "name")
						};
			for (int i = 0; i < volunteer.VolunteersVolunteerTimeSlots.Count; i++)
			{
				ved.ChosenTimeSlots[i] =
					volunteer.VolunteersVolunteerTimeSlots.ElementAt(i).volunteer_timeslot_id;
			}
			return ved;
		}
	}
}