using System;
using System.Linq;
using Conferenceware.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conferenceware.Tests.Models
{
	/// <summary>
	/// Unit tests for the t-shirt size methods of the repository
	/// </summary>
	[TestClass]
	public class RepositoryEventTests
	{
		/// <summary>
		/// Repository to use for testing
		/// </summary>
		private readonly IRepository _repository = RepositoryFactory.GetRepo();
		//private IRepository _repository = new ConferencewareRepository();

		/// <summary>
		/// Generates a tshirt to be inserted (valid, no id)
		/// </summary>
		/// <returns>A Event without an id</returns>
		private static Event GenerateNewEvent1()
		{
			var ev = new Event
						{
							name = "Event1",
							description = "desc1",
							is_visible = true,
							Location = new Location
										{
											building_name = "bldg1",
											max_capacity = 10,
											room_number = "10A",
											notes = "notes1"
										},
							TimeSlot = new TimeSlot
										{
											start_time = new DateTime(2010, 1, 1, 12, 0, 0),
											end_time = new DateTime(2010, 1, 1, 13, 0, 0)
										}
						};
			return ev;
		}

		/// <summary>
		/// Generates second tshirt example
		/// </summary>
		/// <returns>The second example tshirt</returns>
		private static Event GenerateNewEvent2()
		{
			var ev = new Event
			{
				name = "Event2",
				description = "desc2",
				is_visible = true,
				Location = new Location
							{
								building_name = "bldg2",
								max_capacity = 12,
								room_number = "12A",
								notes = "notes2"
							},
				TimeSlot = new TimeSlot
							{
								start_time = new DateTime(2010, 2, 1, 12, 0, 0),
								end_time = new DateTime(2010, 2, 1, 13, 0, 0)
							}
			};
			return ev;
		}

		/// <summary>
		/// Creates third tshirt example
		/// </summary>
		/// <returns>Example location 3</returns>
		private static Event GenerateNewEvent3()
		{
			var ev = new Event
			{
				name = "Event3",
				description = "desc3",
				is_visible = true,
				Location = new Location
							{
								building_name = "bldg3",
								max_capacity = 13,
								room_number = "13A",
								notes = "notes3"
							},
				TimeSlot = new TimeSlot
							{
								start_time = new DateTime(2010, 3, 1, 12, 0, 0),
								end_time = new DateTime(2010, 3, 1, 13, 0, 0)
							}
			};
			return ev;
		}

		private static bool EqualEvents(Event ev1, Event ev2)
		{
			return ev1.is_visible == ev2.is_visible
				   && ev1.location_id == ev2.location_id
				   && ev1.max_attendees == ev2.max_attendees
				   && ev1.name == ev2.name
				   && ev1.timeslot_id == ev2.timeslot_id
				   && ev1.description == ev2.description;
		}

		private void InsertEvents1And2IntoRepo()
		{
			var ev1 = GenerateNewEvent1();
			_repository.AddTimeSlot(ev1.TimeSlot);
			_repository.AddLocation(ev1.Location);
			_repository.AddEvent(ev1);
			var ev2 = GenerateNewEvent2();
			_repository.AddTimeSlot(ev2.TimeSlot);
			_repository.AddLocation(ev2.Location);
			_repository.AddEvent(ev2);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllEvents().Count());
		}


		[TestMethod]
		public void TestEmptyRepoHasNoEvents()
		{
			Assert.AreEqual(0, _repository.GetAllEvents().Count(), "No elements should be in the empty repo");
		}

		[TestMethod]
		public void TestEmptyRepoReturnsNullForGetEventById()
		{
			Assert.IsNull(_repository.GetEventById(1), "Should get null for non-existing element");
		}

		[TestMethod]
		public void TestAddEventToEmptyRepoHasOneAfter()
		{
			_repository.AddEvent(GenerateNewEvent1());
			_repository.Save();
			Assert.AreEqual(1, _repository.GetAllEvents().Count(), "Something should be there");
		}

		[TestMethod]
		public void TestGetEventByIdGivesSomethingAfterInsert()
		{
			var ev1 = GenerateNewEvent1();
			_repository.AddEvent(ev1);
			_repository.Save();
			Assert.IsNotNull(_repository.GetEventById(ev1.id), "The object should have been found");
		}

		[TestMethod]
		public void TestGetEventByIdGivesEvent1AfterInsertingEvent1()
		{
			var ev1 = GenerateNewEvent1();
			_repository.AddEvent(ev1);
			_repository.Save();
			var fromRepo = _repository.GetEventById(ev1.id);
			Assert.IsTrue(EqualEvents(ev1, fromRepo), "The same object should have come back");
		}

		[TestMethod]
		public void TestAddEventAfterAddingTwoGivesThreeForCount()
		{
			InsertEvents1And2IntoRepo();
			_repository.AddEvent(GenerateNewEvent3());
			_repository.Save();
			Assert.AreEqual(3, _repository.GetAllEvents().Count(), "Another location should have been added");
		}

		[TestMethod]
		public void TestUpdateEventCausesGetOfIdToReturnUpdatedVersion()
		{
			var ev = GenerateNewEvent1();
			_repository.AddEvent(ev);
			_repository.Save();
			int evId = ev.id;
			ev.name = "New Name";
			_repository.Save();
			var evTest = _repository.GetEventById(evId);
			Assert.IsTrue(EqualEvents(ev, evTest), "The newly queried object should be the same as the updated one");

		}

		[TestMethod]
		public void TestDeleteEventCausesCountToDecrimentByOne()
		{
			InsertEvents1And2IntoRepo();
			var ev = GenerateNewEvent3();
			_repository.AddEvent(ev);
			_repository.Save();
			_repository.DeleteEvent(ev);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllEvents().Count(), "One less t-shirt size should be present");
		}

		[TestMethod]
		public void TestDeleteEventCausesRepoToReturnNullWhenItsIdIsRequested()
		{
			InsertEvents1And2IntoRepo();
			var ev = GenerateNewEvent3();
			_repository.AddEvent(ev);
			_repository.Save();
			_repository.DeleteEvent(ev);
			_repository.Save();
			Assert.IsNull(_repository.GetEventById(ev.id), "TShirt Size should not exist anymore");
		}

		[TestMethod]
		public void TestDeleteEventWithIdCausesCountToDecrimentByOne()
		{
			InsertEvents1And2IntoRepo();
			var ev = GenerateNewEvent3();
			_repository.AddEvent(ev);
			_repository.Save();
			_repository.DeleteEvent(ev.id);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllEvents().Count(), "One less t-shirt size should exist");
		}

		[TestMethod]
		public void TestDeleteEventWithIdCausesRepoToReturnNullWhenItsIdIsRequested()
		{
			InsertEvents1And2IntoRepo();
			var ev = GenerateNewEvent3();
			_repository.AddEvent(ev);
			_repository.Save();
			_repository.DeleteEvent(ev.id);
			_repository.Save();
			Assert.IsNull(_repository.GetEventById(ev.id), "TShirt Size should not exist anymore");
		}

		[TestMethod]
		public void TestInsertingThenDeletingThenInsertingEventsGeneratesDistinctIds()
		{
			var ev1 = GenerateNewEvent1();
			var ev2 = GenerateNewEvent2();
			_repository.AddEvent(ev1);
			_repository.Save();
			_repository.DeleteEvent(ev1);
			_repository.Save();
			_repository.AddEvent(ev2);
			_repository.Save();
			Assert.AreNotEqual(ev1.id, ev2.id, "Should have generated distinct values");
		}
	}
}
