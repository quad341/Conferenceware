using System.Collections.Generic;
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

		private static string veryLongString =
			"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

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
		public void TestCreateWithValidLocationWithNotesAddsEntryToRepository()
		{
			_controller.Create(_location3);
			Assert.AreEqual(3, _repository.GetAllLocations().Count(), "Should have added an entry");
		}

		[TestMethod]
		public void TestCreateWithValidLocationWithNotesInsertsLocationIntoRepository()
		{
			_controller.Create(_location3);
			Assert.IsTrue(_repository.GetAllLocations().Contains(_location3), "Location 3 should have been inserted");
		}

		[TestMethod]
		public void TestCreateWithValidLocationWithNotesReturnsRedirectToAction()
		{
			var result = _controller.Create(_location3) as RedirectToRouteResult;
			Assert.IsNotNull(result, "Should have given a redirect back");
		}

		[TestMethod]
		public void TestCreateWithValidLocationWithNotesReturnsRedirectToIndex()
		{
			var result = _controller.Create(_location3) as RedirectToRouteResult;
			Assert.AreEqual("Index",
			                result.RouteValues["action"],
			                "Should have redirected to index");
		}

		[TestMethod]
		public void TestCreateWithValidLocationWithoutNotesAddsEntryToRepository()
		{
			_location3.notes = null;
			_controller.Create(_location3);
			Assert.AreEqual(3, _repository.GetAllLocations().Count(), "Should have added an entry");
		}

		[TestMethod]
		public void TestCreateWithValidLocationWithoutNotesInsertsLocationIntoRepository()
		{
			_location3.notes = null;
			_controller.Create(_location3);
			Assert.IsTrue(_repository.GetAllLocations().Contains(_location3), "Location 3 should have been inserted");
		}

		[TestMethod]
		public void TestCreateWithValidLocationWithoutNotesReturnsRedirectToAction()
		{
			_location3.notes = null;
			var result = _controller.Create(_location3) as RedirectToRouteResult;
			Assert.IsNotNull(result, "Should have given a redirect back");
		}

		[TestMethod]
		public void TestCreateWithValidLocationWithoutNotesReturnsRedirectToIndex()
		{
			_location3.notes = null;
			var result = _controller.Create(_location3) as RedirectToRouteResult;
			Assert.AreEqual("Index",
			                result.RouteValues["action"],
			                "Should have redirected to index");
		}

		[TestMethod]
		public void TestCreateWithInvalidLocationNullBuildingNameReturnsViewResult()
		{
			_location3.building_name = null;
			var result = _controller.Create(_location3) as ViewResult;
			Assert.IsNotNull(result);
		}
	}
}
