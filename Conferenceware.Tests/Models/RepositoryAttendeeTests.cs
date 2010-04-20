using System.Linq;
using Conferenceware.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conferenceware.Tests.Models
{
	/// <summary>
	/// Unit tests for the t-shirt size methods of the repository
	/// </summary>
	[TestClass]
	public class RepositoryAttendeeTests
	{
		/// <summary>
		/// Repository to use for testing
		/// </summary>
		private readonly IRepository _repository = RepositoryFactory.GetRepo();
		//private IRepository _repository = new ConferencewareRepository();

		/// <summary>
		/// Generates a tshirt to be inserted (valid, no id)
		/// </summary>
		/// <returns>A Attendee without an id</returns>
		private static Attendee GenerateNewAttendee1()
		{
			var item = new Attendee
						{
							Food = new Food
									{
										name = "Regular"
									},
							TShirtSize = new TShirtSize
											{
												name = "Medium"
											},
							People = new People
										{
											email = "email1@email.com",
											is_alum = true,
											name = "name1",
											phone_number = "555-555-5555"
										}
						};
			return item;
		}

		/// <summary>
		/// Generates second tshirt example
		/// </summary>
		/// <returns>The second example tshirt</returns>
		private static Attendee GenerateNewAttendee2()
		{
			var item = new Attendee
						{
							Food = new Food
									{
										name = "Regular2"
									},
							TShirtSize = new TShirtSize
											{
												name = "Medium2"
											},
							People = new People
										{
											email = "email2@email.com",
											is_alum = true,
											name = "name2",
											phone_number = "555-555-5555"
										}
						};
			return item;
		}

		/// <summary>
		/// Creates third tshirt example
		/// </summary>
		/// <returns>Example location 3</returns>
		private static Attendee GenerateNewAttendee3()
		{
			var item = new Attendee
						{
							Food = new Food
									{
										name = "Regular3"
									},
							TShirtSize = new TShirtSize
											{
												name = "Medium3"
											},
							People = new People
										{
											email = "email3@email.com",
											is_alum = true,
											name = "name3",
											phone_number = "555-555-5555"
										}
						};
			return item;
		}

		private static bool EqualPeople(People p1, People p2)
		{
			return p1.name == p2.name
				   && p1.is_alum == p2.is_alum
				   && p1.phone_number == p2.phone_number
				   && p1.email == p2.email;
		}

		private static bool EqualAttendees(Attendee item1, Attendee item2)
		{
			return EqualPeople(item1.People, item2.People)
				   && item1.tshirt_id == item2.tshirt_id
				   && item1.food_choice_id == item2.food_choice_id;
		}

		private void InsertAttendees1And2IntoRepo()
		{
			var item1 = GenerateNewAttendee1();
			_repository.AddFood(item1.Food);
			_repository.AddTShirtSize(item1.TShirtSize);
			_repository.AddAttendee(item1);
			var item2 = GenerateNewAttendee2();
			_repository.AddFood(item2.Food);
			_repository.AddTShirtSize(item2.TShirtSize);
			_repository.AddAttendee(item2);
			Assert.AreEqual(2, _repository.GetAllAttendees().Count());
		}


		[TestMethod]
		public void TestEmptyRepoHasNoAttendees()
		{
			Assert.AreEqual(0, _repository.GetAllAttendees().Count(), "No elements should be in the empty repo");
		}

		[TestMethod]
		public void TestEmptyRepoReturnsNullForGetAttendeeById()
		{
			Assert.IsNull(_repository.GetAttendeeById(1), "Should get null for non-existing element");
		}

		[TestMethod]
		public void TestAddAttendeeToEmptyRepoHasOneAfter()
		{
			_repository.AddAttendee(GenerateNewAttendee1());
			_repository.Save();
			Assert.AreEqual(1, _repository.GetAllAttendees().Count(), "Something should be there");
		}

		[TestMethod]
		public void TestGetAttendeeByIdGivesSomethingAfterInsert()
		{
			var item1 = GenerateNewAttendee1();
			_repository.AddAttendee(item1);
			_repository.Save();
			Assert.IsNotNull(_repository.GetAttendeeById(item1.person_id), "The object should have been found");
		}

		[TestMethod]
		public void TestGetAttendeeByIdGivesAttendee1AfterInsertingAttendee1()
		{
			var item1 = GenerateNewAttendee1();
			_repository.AddAttendee(item1);
			_repository.Save();
			var fromRepo = _repository.GetAttendeeById(item1.person_id);
			Assert.IsTrue(EqualAttendees(item1, fromRepo), "The same object should have come back");
		}

		[TestMethod]
		public void TestAddAttendeeAfterAddingTwoGivesThreeForCount()
		{
			InsertAttendees1And2IntoRepo();
			_repository.AddAttendee(GenerateNewAttendee3());
			_repository.Save();
			Assert.AreEqual(3, _repository.GetAllAttendees().Count(), "Another location should have been added");
		}

		[TestMethod]
		public void TestUpdateAttendeeCausesGetOfIdToReturnUpdatedVersion()
		{
			var item = GenerateNewAttendee1();
			_repository.AddAttendee(item);
			_repository.Save();
			int itemId = item.person_id;
			item.People.name = "New Name";
			_repository.Save();
			var itemTest = _repository.GetAttendeeById(itemId);
			Assert.IsTrue(EqualAttendees(item, itemTest), "The newly queried object should be the same as the updated one");

		}

		[TestMethod]
		public void TestDeleteAttendeeCausesCountToDecrimentByOne()
		{
			InsertAttendees1And2IntoRepo();
			var item = GenerateNewAttendee3();
			_repository.AddAttendee(item);
			_repository.Save();
			_repository.DeleteAttendee(item);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllAttendees().Count(), "One less t-shirt size should be present");
		}

		[TestMethod]
		public void TestDeleteAttendeeCausesRepoToReturnNullWhenItsIdIsRequested()
		{
			InsertAttendees1And2IntoRepo();
			var item = GenerateNewAttendee3();
			_repository.AddAttendee(item);
			_repository.Save();
			_repository.DeleteAttendee(item);
			_repository.Save();
			Assert.IsNull(_repository.GetAttendeeById(item.person_id), "TShirt Size should not exist anymore");
		}

		[TestMethod]
		public void TestDeleteAttendeeWithIdCausesCountToDecrimentByOne()
		{
			InsertAttendees1And2IntoRepo();
			var item = GenerateNewAttendee3();
			_repository.AddAttendee(item);
			_repository.Save();
			_repository.DeleteAttendee(item.person_id);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllAttendees().Count(), "One less t-shirt size should exist");
		}

		[TestMethod]
		public void TestDeleteAttendeeWithIdCausesRepoToReturnNullWhenItsIdIsRequested()
		{
			InsertAttendees1And2IntoRepo();
			var item = GenerateNewAttendee3();
			_repository.AddAttendee(item);
			_repository.Save();
			_repository.DeleteAttendee(item.person_id);
			_repository.Save();
			Assert.IsNull(_repository.GetAttendeeById(item.person_id), "TShirt Size should not exist anymore");
		}

		[TestMethod]
		public void TestInsertingThenDeletingThenInsertingAttendeesGeneratesDistinctIds()
		{
			var item1 = GenerateNewAttendee1();
			var item2 = GenerateNewAttendee2();
			_repository.AddAttendee(item1);
			_repository.Save();
			_repository.DeleteAttendee(item1);
			_repository.Save();
			_repository.AddAttendee(item2);
			_repository.Save();
			Assert.AreNotEqual(item1.person_id, item2.person_id, "Should have generated distinct values");
		}
	}
}
