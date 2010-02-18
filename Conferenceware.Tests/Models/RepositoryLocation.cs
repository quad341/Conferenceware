using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Conferenceware.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conferenceware.Tests.Models
{
	/// <summary>
	/// Unit tests for the location methods of the repository
	/// </summary>
	[TestClass]
	public class RepositoryLocation
	{
		/// <summary>
		/// Repository to use for testing
		/// </summary>
		private IRepository _repository = new TestRepository();
		//private IRepository _repository = new ConferencewareRepository();

		/// <summary>
		/// Internal method to generate the first example location
		/// </summary>
		/// <returns>Example location 1</returns>
		private Location GenerateLocation1()
		{
			var l = new Location
			        	{
			        		id = 10,
			        		building_name = "Siebel Center",
			        		max_capacity = 75,
			        		notes = "Food allowed",
			        		room_number = "2405"
			        	};
			return l;
		}

		/// <summary>
		/// Generates second location example
		/// </summary>
		/// <returns>The second example location</returns>
		private Location GenerateLocation2()
		{
			var l = new Location
			        	{
			        		id = 25,
			        		building_name = "Digital Computer Laboritory",
			        		max_capacity = 150,
			        		notes = "Big lecture hall in DCL",
			        		room_number = "1320"
			        	};
			return l;
		}

		/// <summary>
		/// Generates a location to be inserted (valid location, no id)
		/// </summary>
		/// <returns>A location without an id</returns>
		private Location GenerateNewLocation1()
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
		/// Checks equality of two locations for simple properties other than id
		/// </summary>
		/// <param name="loc1">The first location to consider</param>
		/// <param name="loc2">The second location to consider</param>
		/// <returns>Whether or not all the properties except for id are the same</returns>
		private bool EqualLocationProperties(Location loc1, Location loc2)
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
	}
}
