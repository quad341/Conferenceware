using System.Linq;
using System.Web.Mvc;
using Conferenceware.Controllers;
using Conferenceware.Models;
using Conferenceware.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conferenceware.Tests.Controllers
{
	/// <summary>
	/// Unit tests for the functionality of the Location Controller
	/// </summary>
	[TestClass]
	public class LocationControllerTests
	{
		/// <summary>
		/// Repository for storing the test data
		/// </summary>
		private IRepository _repository;

		/// <summary>
		/// The controller that will be tested
		/// </summary>
		private LocationController _controller;

		private Location _location1;
		private Location _location2;
		private Location _location3;

		[TestInitialize]
		public void Initialize()
		{
			InitRepoAndTwoLocations();
			_controller = new LocationController(_repository);
		}

		private void InitRepoAndTwoLocations()
		{
			_location1 = new Location
			            	{
			            		building_name = "Siebel Center",
			            		room_number = "1404",
			            		max_capacity = 175,
			            		notes = "Large lecture hall in Siebel"
			            	};
			_location2 = new Location
			            	{
			            		building_name = "Digital Computer Laboratory",
			            		room_number = "1320",
			            		max_capacity = 200,
			            		notes = "Power avaiable to people in the room"
			            	};
			_location3 = new Location
			            	{
			            		building_name = "Building",
			            		room_number = "Room",
			            		max_capacity = 10,
			            		notes = "Notes"
			            	};
			
			_repository = new TestRepository();
			_repository.AddLocation(_location1);
			_repository.AddLocation(_location2);
			_repository.Save();
		}

		private FormCollection ConvertLocationToFormCollection(Location loc)
		{
			var fc = new FormCollection();
			fc.Add("id", loc.id.ToString());
			fc.Add("building_name", loc.building_name);
			fc.Add("room_number", loc.room_number);
			fc.Add("max_capacity", loc.max_capacity.ToString());
			fc.Add("notes", loc.notes);
			return fc;
		}

		/// <summary>
		/// Checks if two locations are equivalent for data (less id)
		/// </summary>
		/// <param name="loc1">The first location to check</param>
		/// <param name="loc2">The second location to check</param>
		/// <returns>Whether or not the locations are equivalent</returns>
		private static bool LocationsAreEquivalent(Location loc1, Location loc2)
		{
			return loc1.building_name == loc2.building_name
			       && loc1.room_number == loc2.room_number
			       && loc1.max_capacity == loc2.max_capacity
			       && loc1.notes == loc2.notes;
		}

		[TestMethod]
		public void TestIndexGivesBackViewResultResponse()
		{
			var result = _controller.Index() as ViewResult;
			Assert.IsNotNull(result, "Should have gotten a view result back");
		}

		[TestMethod]
		public void TestIndexReturnsIndexView()
		{
			var result = _controller.Index() as ViewResult;
			Assert.AreEqual("Index",result.ViewName, "Should have given the index view back");
		}

		[TestMethod]
		public void TestIndexGetsListForModel()
		{
			var result = _controller.Index() as ViewResult;
			var model = result.ViewData.Model as IQueryable<Location>;
			Assert.IsNotNull(model,"Should have gotten a list of locations for model type");
		}

		[TestMethod]
		public void TestIndexModelHasTwoItems()
		{
			var result = _controller.Index() as ViewResult;
			var model = result.ViewData.Model as IQueryable<Location>;
			Assert.AreEqual(2, model.Count(), "Should have two items in model");
		}

		[TestMethod]
		public void TestIndexModelContainsLocation1()
		{
			var result = _controller.Index() as ViewResult;
			var model = result.ViewData.Model as IQueryable<Location>;
			Assert.IsTrue(model.Contains(_location1), "Model should have location 1 in it");
		}

		[TestMethod]
		public void TestIndexModelContainsLocation2()
		{
			var result = _controller.Index() as ViewResult;
			var model = result.ViewData.Model as IQueryable<Location>;
			Assert.IsTrue(model.Contains(_location2), "Model should have location 2 in it");
		}

		[TestMethod]
		public void TestCreateReturnsViewResult()
		{
			var result = _controller.Create() as ViewResult;
			Assert.IsNotNull(result, "Should have gotten ViewResult back");
		}

		[TestMethod]
		public void TestCreateReturnsCreateView()
		{
			var result = _controller.Create() as ViewResult;
			Assert.AreEqual("Create", result.ViewName, "Should have returned the create view");
		}

		[TestMethod]
		public void TestCreateModelIsALocation()
		{
			var result = _controller.Create() as ViewResult;
			var model = result.ViewData.Model as Location;
			Assert.IsNotNull(model, "The model should have been a location");
		}

		[TestMethod]
		public void TestCreateModelIsNewLocation()
		{
			var result = _controller.Create() as ViewResult;
			var model = result.ViewData.Model as Location;
			var expected = new Location();
			Assert.IsTrue(LocationsAreEquivalent(expected, model), "Model should be a new Location");
		}

		[TestMethod]
		public void TestCreateWithValidLocationAddsEntryToRepository()
		{
			_controller.Create(_location3);
			Assert.AreEqual(3, _repository.GetAllLocations().Count(), "Should have added an entry");
		}

		[TestMethod]
		public void TestCreateWithValidLocationInsertsLocationIntoRepository()
		{
			_controller.Create((_location3));
			Assert.IsTrue(_repository.GetAllLocations().Contains(_location3), "Location 3 should have been inserted");
		}

		[TestMethod]
		public void TestCreateWithValidLocationReturnsRedirectToAction()
		{
			var result = _controller.Create((_location3)) as RedirectToRouteResult;
			Assert.IsNotNull(result, "Should have given a redirect back");
		}

		[TestMethod]
		public void TestCreateWithValidLocationReturnsRedirectToIndex()
		{
			var result = _controller.Create((_location3)) as RedirectToRouteResult;
			Assert.AreEqual("Index",
			                result.RouteValues["action"],
			                "Should have redirected to index");
		}

		[TestMethod]
		public void TestCreateWithInvalidLocationReturnsViewResult()
		{
			_controller.ModelState.AddModelError("*","Invalid Model State");
			var result = _controller.Create((_location3)) as ViewResult;
			Assert.IsNotNull(result, "Should have given a view result back");
		}

		[TestMethod]
		public void TestCreateWithInvalidLocationReturnsEditView()
		{
			_controller.ModelState.AddModelError("*","Invalid Model State");
			var result = _controller.Create((_location3)) as ViewResult;
			Assert.AreEqual("Create", result.ViewName, "Should have given edit view back");
		}

		[TestMethod]
		public void TestCreateWithInvalidLocationReturnsViewWithLocationAsModel()
		{
			_controller.ModelState.AddModelError("*","Invalid Model State");
			var result = _controller.Create((_location3)) as ViewResult;
			var model = result.ViewData.Model as Location;
			Assert.IsNotNull(model, "Should have gotten a location as the model");
		}

		[TestMethod]
		public void TestCreateWithInvalidLocationReturnsViewWithInitialModel()
		{
			_controller.ModelState.AddModelError("*","Invalid Model State");
			var result = _controller.Create((_location3)) as ViewResult;
			var model = result.ViewData.Model as Location;
			Assert.IsTrue(LocationsAreEquivalent(_location3, model));
		}

		[TestMethod]
		public void TestEditWithValidIdReturnsViewResult()
		{
			var result = _controller.Edit(_location1.id) as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void TestEditWithValidIdReturnsEditView()
		{
			var result = _controller.Edit(_location1.id) as ViewResult;
			Assert.AreEqual("Edit", result.ViewName);
		}

		[TestMethod]
		public void TestEditWithValidIdHasLocationAsModel()
		{
			var result = _controller.Edit(_location1.id) as ViewResult;
			var model = result.ViewData.Model as Location;
			Assert.IsNotNull(model);
		}

		[TestMethod]
		public void TestEditWithValidIdReturnsCorrectModel()
		{
			var result = _controller.Edit(_location1.id) as ViewResult;
			var expected = _repository.GetLocationById(_location1.id);
			var model = result.ViewData.Model as Location;
			Assert.IsTrue(LocationsAreEquivalent(expected, model));
		}

		[TestMethod]
		public void TestEditWithInvalidIdReturnsViewResult()
		{
			var result = _controller.Edit(-1) as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void TestEditWithInvalidIdReturnsLocationNotFoundView()
		{
			var result = _controller.Edit(-1) as ViewResult;
			Assert.AreEqual("LocationNotFound", result.ViewName);
		}
		
		[TestMethod]
		public void TestEditSubmitWithValidIDAndLocationUpdatesRepo()
		{
			_location1.building_name = "New name";
			_controller.Edit(_location1.id, ConvertLocationToFormCollection(_location1));
			var updated = _repository.GetLocationById(_location1.id);
			Assert.AreEqual(_location1, updated);
		}

		[TestMethod]
		public void TestEditSubmitWithValidIDAndLocationDoesNotAddNewEntryToRepo()
		{
			_location1.building_name = "New name";
			_controller.Edit(_location1.id, ConvertLocationToFormCollection(_location1));
			Assert.AreEqual(2, _repository.GetAllLocations().Count());
		}

		[TestMethod]
		public void TestEditSubmitWithValidIdAndLocationReturnsRedirectToAction()
		{
			_location1.building_name = "New name";
			var fc = ConvertLocationToFormCollection(_location1);
			_controller.ValueProvider = fc.ToValueProvider();
			var result = _controller.Edit(_location1.id, fc) as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void TestEditSubmitWithValidIdAndLocationReturnsRedirectToIndex()
		{
			var result = _controller.Edit(_location1.id,
			                              ConvertLocationToFormCollection(_location1)) as
			             RedirectToRouteResult;
			Assert.AreEqual("Index",result.RouteValues["action"]);
		}

		[TestMethod]
		public void TestEditSubmitWithInvalidIdReturnsViewResult()
		{
			var result = _controller.Edit(-1, null) as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void TestEditSubmitWithInvalidIdReturnsLocationNotFoundView()
		{
			var result = _controller.Edit(-1, null) as ViewResult;
			Assert.AreEqual("LocationNotFound",result.ViewName);
		}

		[TestMethod]
		public void TestEditSubmitWithInvalidLocationReturnsViewResult()
		{
			_controller.ModelState.AddModelError("*","Invalid Model State");
			var result =
				_controller.Edit(_location1.id, ConvertLocationToFormCollection(_location1)) as
				ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void TestEditSubmitWithInvalidLocationReturnsEditView()
		{
			_controller.ModelState.AddModelError("*","Invalid Model State");
			var result =
				_controller.Edit(_location1.id, ConvertLocationToFormCollection(_location1)) as
				ViewResult;
			Assert.AreEqual("Edit",result.ViewName);
		}

		[TestMethod]
		public void TestEditSubmitWithInvalidLocationReturnsViewWithSameModel()
		{
			_controller.ModelState.AddModelError("*","Invalid Model State");
			var result =
				_controller.Edit(_location1.id, ConvertLocationToFormCollection(_location1)) as
				ViewResult;
			Assert.AreEqual(_location1,result.ViewData.Model);
		}

		[TestMethod]
		public void TestDeleteWithValidIdRemovesEntryFromRepository()
		{
			_controller.Delete(_location1.id);
			Assert.AreEqual(1, _repository.GetAllLocations().Count());
		}

		[TestMethod]
		public void TestDeleteWithValidIdRemovesGivenLocationFromRepository()
		{
			_controller.Delete(_location1.id);
			Assert.IsNull(_repository.GetLocationById(_location1.id));
		}

		[TestMethod]
		public void TestDeleteWithValidIdReturnsRedirectAction()
		{
			var result = _controller.Delete(_location1.id) as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void TestDeleteWithValidIdReturnsRedirectToIndex()
		{
			var result = _controller.Delete(_location1.id) as RedirectToRouteResult;
			Assert.AreEqual("Index", result.RouteValues["action"]);
		}

		[TestMethod]
		public void TestDeleteWithInvalidIdReturnsViewResult()
		{
			var result = _controller.Delete(-1) as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void TestDeleteWithInvalidIdReturnsLocationNotFoundView()
		{
			var result = _controller.Delete(-1) as ViewResult;
			Assert.AreEqual("LocationNotFound", result.ViewName);
		}
	}
}
