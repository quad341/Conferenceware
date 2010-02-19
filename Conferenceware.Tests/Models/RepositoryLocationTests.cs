using System.Linq;
using Conferenceware.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conferenceware.Tests.Models
{
	/// <summary>
	/// Unit tests for the location methods of the repository
	/// </summary>
	[TestClass]
	public class RepositoryLocationTests
	{
		/// <summary
		/// Repository to use for testing
		/// </summary>
		private readonly IRepository _repository = new TestRepository();
		//private IRepository _repository = new ConferencewareRepository();

		/// <summary>
		/// Generates a location to be inserted (valid location, no id)
		/// </summary>
		/// <returns>A location without an id</returns>
		private static Location GenerateNewLocation1()
		{
			var l = new Location
			        	{
			        		building_name = "Siebel Center",
			        		room_number = "1404",
			        		max_capacity = 200,
			        		notes = "Big lecture hall in Siebel"
			        	};
			return l;
		}

		/// <summary>
		/// Generates second location example
		/// </summary>
		/// <returns>The second example location</returns>
		private static Location GenerateNewLocation2()
		{
			var l = new Location
			        	{
			        		building_name = "Digital Computer Laboritory",
			        		max_capacity = 150,
			        		notes = "Big lecture hall in DCL",
			        		room_number = "1320"
			        	};
			return l;
		}

		/// <summary>
		/// Internal method to generate the first example location
		/// </summary>
		/// <returns>Example location 1</returns>
		private static Location GenerateNewLocation3()
		{
			var l = new Location
			        	{
			        		building_name = "Siebel Center",
			        		max_capacity = 75,
			        		notes = "Food allowed",
			        		room_number = "2405"
			        	};
			return l;
		}

		private void InsertLocations1And2IntoRepo()
		{
			_repository.AddLocation(GenerateNewLocation1());
			_repository.AddLocation(GenerateNewLocation2());
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllLocations().Count());
		}

		/// <summary>
		/// Checks equality of two locations for simple properties other than id
		/// </summary>
		/// <param name="loc1">The first location to consider</param>
		/// <param name="loc2">The second location to consider</param>
		/// <returns>Whether or not all the properties except for id are the same</returns>
		private static bool EqualLocationProperties(Location loc1, Location loc2)
		{
			return loc1.building_name == loc2.building_name &&
			       loc1.max_capacity == loc2.max_capacity &&
				   loc1.notes == loc2.notes &&
			       loc1.room_number == loc2.room_number;
		}

		[TestMethod]
		public void TestEmptyRepoHasNoLocations()
		{
			Assert.AreEqual(0, _repository.GetAllLocations().Count(), "No elements should be in the empty repo");
		}

		[TestMethod]
		public void TestEmptyRepoReturnsNullForGetLocationById()
		{
			Assert.IsNull(_repository.GetLocationById(1), "Should get null for non-existing element");
		}

		[TestMethod]
		public void TestAddLocationToEmptyRepoHasOneAfter()
		{
			_repository.AddLocation(GenerateNewLocation1());
			_repository.Save();
			Assert.AreEqual(1,_repository.GetAllLocations().Count(), "Something should be there");
		}

		[TestMethod]
		public void TestGetLocationByIdGivesSomethingAfterInsert()
		{
			Location loc1 = GenerateNewLocation1();
			_repository.AddLocation(loc1);
			_repository.Save();
			Assert.IsNotNull(_repository.GetLocationById(loc1.id), "The object should have been found");
		}

		[TestMethod]
		public void TestGetLocationByIdGivesLocation1AfterInsertingLocation1()
		{
			Location loc1 = GenerateNewLocation1();
			_repository.AddLocation(loc1);
			_repository.Save();
			Location fromRepo = _repository.GetLocationById(loc1.id);
			Assert.IsTrue(EqualLocationProperties(fromRepo, loc1), "The same object should have come back");
		}

		[TestMethod]
		public void TestAddLocationAfterAddingTwoGivesThreeForCount()
		{
			InsertLocations1And2IntoRepo();
			_repository.AddLocation(GenerateNewLocation3());
			_repository.Save();
			Assert.AreEqual(3, _repository.GetAllLocations().Count(), "Another location should have been added");
		}

		[TestMethod]
		public void TestUpdateLocationCausesGetOfIdToReturnUpdatedVersion()
		{
			Location loc = GenerateNewLocation2();
			_repository.AddLocation(loc);
			_repository.Save();
			int locId = loc.id;
			loc.building_name = "New Building";
			loc.notes = "New Notes";
			_repository.Save();
			Location testLoc = _repository.GetLocationById(locId);
			Assert.IsTrue(EqualLocationProperties(loc, testLoc), "The newly queried object should be the same as the updated one");

		}

		[TestMethod]
		public void TestDeleteLocationCausesCountToDecrimentByOne()
		{
			InsertLocations1And2IntoRepo();
			Location loc = GenerateNewLocation1();
			_repository.AddLocation(loc);
			_repository.Save();
			_repository.DeleteLocation(loc);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllLocations().Count(), "One less location should be present");
		}

		[TestMethod]
		public void TestDeleteLocationCausesRepoToReturnNullWhenItsIdIsRequested()
		{
			InsertLocations1And2IntoRepo();
			Location loc = GenerateNewLocation1();
			_repository.AddLocation(loc);
			_repository.Save();
			_repository.DeleteLocation(loc);
			_repository.Save();
			Assert.IsNull(_repository.GetLocationById(loc.id), "Location should not exist anymore");
		}

		[TestMethod]
		public void TestDeleteLocationWithIdCausesCountToDecrimentByOne()
		{
			InsertLocations1And2IntoRepo();
			Location loc = GenerateNewLocation1();
			_repository.AddLocation(loc);
			_repository.Save();
			_repository.DeleteLocation(loc.id);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllLocations().Count(), "One less location should exist");
		}

		[TestMethod]
		public void TestDeleteLocationWithIdCausesRepoToReturnNullWhenItsIdIsRequested()
		{
			InsertLocations1And2IntoRepo();
			Location loc = GenerateNewLocation1();
			_repository.AddLocation(loc);
			_repository.Save();
			_repository.DeleteLocation(loc.id);
			_repository.Save();
			Assert.IsNull(_repository.GetLocationById(loc.id), "Location should not exist anymore");
		}

		[TestMethod]
		public void TestInsertingThenDeletingThenInsertingLocationsGeneratesDistinctIds()
		{
			Location loc1 = GenerateNewLocation1();
			Location loc2 = GenerateNewLocation2();
			_repository.AddLocation(loc1);
			_repository.Save();
			_repository.DeleteLocation(loc1);
			_repository.Save();
			_repository.AddLocation(loc2);
			_repository.Save();
			Assert.AreNotEqual(loc1.id, loc2.id, "Should have generated distinct values");
		}
	}
}
