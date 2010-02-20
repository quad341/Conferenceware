using Conferenceware.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conferenceware.Tests.Models
{
	/// <summary>
	/// Tests validation for Location objects
	/// </summary>
	[TestClass]
	public class LocationTests
	{
		/*
		[TestMethod]
		public void TestValidLocationWithNotesIsValid()
		{
			var l = new Location
			        	{
			        		BuildingName = "Siebel",
			        		RoomNumber = "1404",
			        		MaxCapacity = 100,
			        		Notes = "notes"
			        	};
			Assert.IsTrue(l.IsValid);
		}

		[TestMethod]
		public void TestValidLocationWithoutNotesIsValid()
		{
			var l = new Location
			        	{
			        		BuildingName = "Siebel",
			        		RoomNumber = "1404",
			        		MaxCapacity = 100
			        	};
			Assert.IsTrue(l.IsValid);
		}

		[TestMethod]
		public void TestNullBuildingNameIsNotValid()
		{
			var l = new Location
			             	{
			             		BuildingName = null,
			             		MaxCapacity = 1,
			             		RoomNumber = "room"
			             	};
			Assert.IsFalse(l.IsValid);
		}

		[TestMethod]
		public void Test256CharacterBuildingNameIsNotValid()
		{
			var l = new Location
			        	{
			        		BuildingName =
			        			"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
			        		RoomNumber = "room",
			        		MaxCapacity = 1
			        	};
			Assert.IsFalse(l.IsValid);
		}

		[TestMethod]
		public void TestNullRoomNumberIsNotValid()
		{
			var l = new Location
						{
							BuildingName = "building",
							MaxCapacity = 1,
							RoomNumber = null
						};
			Assert.IsFalse(l.IsValid);
		}

		[TestMethod]
		public void Test256CharacterRoomNumberIsNotValid()
		{
			var l = new Location
			{
				RoomNumber = 
					"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
				BuildingName = "building",
				MaxCapacity = 1
			};
			Assert.IsFalse(l.IsValid);
		}

		[TestMethod]
		public void TestZeroMaxCapacityIsNotValid()
		{
			var l = new Location
			{
				RoomNumber = "room",
				BuildingName = "building",
				MaxCapacity = 0
			};
			Assert.IsFalse(l.IsValid);
		}

		[TestMethod]
		public void TestNegativeMaxCapacityIsNotValid()
		{
			var l = new Location
			{
				RoomNumber = "room",
				BuildingName = "building",
				MaxCapacity = -10
			};
			Assert.IsFalse(l.IsValid);
		}
		 */
	}
}
