using System.Linq;
using Conferenceware.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conferenceware.Tests.Models
{
	/// <summary>
	/// Unit tests for the t-shirt size methods of the repository
	/// </summary>
	[TestClass]
	public class RepositorySpeakerTests
	{
		/// <summary>
		/// Repository to use for testing
		/// </summary>
		private readonly IRepository _repository = RepositoryFactory.GetRepo();
		//private IRepository _repository = new ConferencewareRepository();

		/// <summary>
		/// Generates a tshirt to be inserted (valid, no id)
		/// </summary>
		/// <returns>A Speaker without an id</returns>
		private static Speaker GenerateNewSpeaker1()
		{
			var item = new Speaker
			{
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
		private static Speaker GenerateNewSpeaker2()
		{
			var item = new Speaker
			{
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
		private static Speaker GenerateNewSpeaker3()
		{
			var item = new Speaker
			{
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

		private static bool EqualSpeakers(Speaker item1, Speaker item2)
		{
			return EqualPeople(item1.People, item2.People);
		}

		private void InsertSpeakers1And2IntoRepo()
		{
			var item1 = GenerateNewSpeaker1();
			_repository.AddSpeaker(item1);
			var item2 = GenerateNewSpeaker2();
			_repository.AddSpeaker(item2);
			Assert.AreEqual(2, _repository.GetAllSpeakers().Count());
		}


		[TestMethod]
		public void TestEmptyRepoHasNoSpeakers()
		{
			Assert.AreEqual(0, _repository.GetAllSpeakers().Count(), "No elements should be in the empty repo");
		}

		[TestMethod]
		public void TestEmptyRepoReturnsNullForGetSpeakerById()
		{
			Assert.IsNull(_repository.GetSpeakerById(1), "Should get null for non-existing element");
		}

		[TestMethod]
		public void TestAddSpeakerToEmptyRepoHasOneAfter()
		{
			_repository.AddSpeaker(GenerateNewSpeaker1());
			_repository.Save();
			Assert.AreEqual(1, _repository.GetAllSpeakers().Count(), "Something should be there");
		}

		[TestMethod]
		public void TestGetSpeakerByIdGivesSomethingAfterInsert()
		{
			var item1 = GenerateNewSpeaker1();
			_repository.AddSpeaker(item1);
			_repository.Save();
			Assert.IsNotNull(_repository.GetSpeakerById(item1.People.id), "The object should have been found");
		}

		[TestMethod]
		public void TestGetSpeakerByIdGivesSpeaker1AfterInsertingSpeaker1()
		{
			var item1 = GenerateNewSpeaker1();
			_repository.AddSpeaker(item1);
			_repository.Save();
			var fromRepo = _repository.GetSpeakerById(item1.People.id);
			Assert.IsTrue(EqualSpeakers(item1, fromRepo), "The same object should have come back");
		}

		[TestMethod]
		public void TestAddSpeakerAfterAddingTwoGivesThreeForCount()
		{
			InsertSpeakers1And2IntoRepo();
			_repository.AddSpeaker(GenerateNewSpeaker3());
			_repository.Save();
			Assert.AreEqual(3, _repository.GetAllSpeakers().Count(), "Another location should have been added");
		}

		[TestMethod]
		public void TestUpdateSpeakerCausesGetOfIdToReturnUpdatedVersion()
		{
			var item = GenerateNewSpeaker1();
			_repository.AddSpeaker(item);
			_repository.Save();
			int itemId = item.People.id;
			item.People.name = "New Name";
			_repository.Save();
			var itemTest = _repository.GetSpeakerById(itemId);
			Assert.IsTrue(EqualSpeakers(item, itemTest), "The newly queried object should be the same as the updated one");

		}

		[TestMethod]
		public void TestDeleteSpeakerCausesCountToDecrimentByOne()
		{
			InsertSpeakers1And2IntoRepo();
			var item = GenerateNewSpeaker3();
			_repository.AddSpeaker(item);
			_repository.Save();
			_repository.DeleteSpeaker(item);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllSpeakers().Count(), "One less t-shirt size should be present");
		}

		[TestMethod]
		public void TestDeleteSpeakerWithIdCausesCountToDecrimentByOne()
		{
			InsertSpeakers1And2IntoRepo();
			var item = GenerateNewSpeaker3();
			_repository.AddSpeaker(item);
			_repository.Save();
			_repository.DeleteSpeaker(item.People.id);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllSpeakers().Count(), "One less t-shirt size should exist");
		}


		[TestMethod]
		public void TestInsertingThenDeletingThenInsertingSpeakersGeneratesDistinctIds()
		{
			var item1 = GenerateNewSpeaker1();
			var item2 = GenerateNewSpeaker2();
			_repository.AddSpeaker(item1);
			_repository.Save();
			var id = item1.People.id;
			_repository.DeleteSpeaker(item1);
			_repository.Save();
			_repository.AddSpeaker(item2);
			_repository.Save();
			Assert.AreNotEqual(id, item2.People.id, "Should have generated distinct values");
		}
	}
}
