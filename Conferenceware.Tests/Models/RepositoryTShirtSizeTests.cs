using System.Linq;
using Conferenceware.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conferenceware.Tests.Models
{
	/// <summary>
	/// Unit tests for the t-shirt size methods of the repository
	/// </summary>
	[TestClass]
	public class RepositoryTShirtSizeTests
	{
		/// <summary>
		/// Repository to use for testing
		/// </summary>
		private readonly IRepository _repository = RepositoryFactory.GetRepo();
		//private IRepository _repository = new ConferencewareRepository();

		/// <summary>
		/// Generates a tshirt to be inserted (valid, no id)
		/// </summary>
		/// <returns>A TShirtSize without an id</returns>
		private static TShirtSize GenerateNewTShirtSize1()
		{
			var tss = new TShirtSize
			{
				name = "Small"
			};
			return tss;
		}

		/// <summary>
		/// Generates second tshirt example
		/// </summary>
		/// <returns>The second example tshirt</returns>
		private static TShirtSize GenerateNewTShirtSize2()
		{
			var tss = new TShirtSize
						{
							name = "Medium"
						};
			return tss;
		}

		/// <summary>
		/// Creates third tshirt example
		/// </summary>
		/// <returns>Example location 3</returns>
		private static TShirtSize GenerateNewTShirtSize3()
		{
			var tss = new TShirtSize
						{
							name = "Large"
						};
			return tss;
		}

		private void InsertSizes1And2IntoRepo()
		{
			_repository.AddTShirtSize(GenerateNewTShirtSize1());
			_repository.AddTShirtSize(GenerateNewTShirtSize2());
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllTShirtSizes().Count());
		}


		[TestMethod]
		public void TestEmptyRepoHasNoTShirtSizes()
		{
			Assert.AreEqual(0, _repository.GetAllTShirtSizes().Count(), "No elements should be in the empty repo");
		}

		[TestMethod]
		public void TestEmptyRepoReturnsNullForGetTShirtSizeById()
		{
			Assert.IsNull(_repository.GetTShirtSizeById(1), "Should get null for non-existing element");
		}

		[TestMethod]
		public void TestAddTShirtSizeToEmptyRepoHasOneAfter()
		{
			_repository.AddTShirtSize(GenerateNewTShirtSize1());
			_repository.Save();
			Assert.AreEqual(1, _repository.GetAllTShirtSizes().Count(), "Something should be there");
		}

		[TestMethod]
		public void TestGetTShirtSizeByIdGivesSomethingAfterInsert()
		{
			var tss1 = GenerateNewTShirtSize1();
			_repository.AddTShirtSize(tss1);
			_repository.Save();
			Assert.IsNotNull(_repository.GetTShirtSizeById(tss1.id), "The object should have been found");
		}

		[TestMethod]
		public void TestGetTShirtSizeByIdGivesTShirtSize1AfterInsertingTShirtSize1()
		{
			var tss1 = GenerateNewTShirtSize1();
			_repository.AddTShirtSize(tss1);
			_repository.Save();
			var fromRepo = _repository.GetTShirtSizeById(tss1.id);
			Assert.IsTrue(fromRepo.name == tss1.name, "The same object should have come back");
		}

		[TestMethod]
		public void TestAddTShirtSizeAfterAddingTwoGivesThreeForCount()
		{
			InsertSizes1And2IntoRepo();
			_repository.AddTShirtSize(GenerateNewTShirtSize3());
			_repository.Save();
			Assert.AreEqual(3, _repository.GetAllTShirtSizes().Count(), "Another location should have been added");
		}

		[TestMethod]
		public void TestUpdateTShirtSizeCausesGetOfIdToReturnUpdatedVersion()
		{
			var tss = GenerateNewTShirtSize1();
			_repository.AddTShirtSize(tss);
			_repository.Save();
			int tssId = tss.id;
			tss.name = "New Name";
			_repository.Save();
			var testLoc = _repository.GetTShirtSizeById(tssId);
			Assert.IsTrue(testLoc.name == tss.name, "The newly queried object should be the same as the updated one");

		}

		[TestMethod]
		public void TestDeleteTShirtSizeCausesCountToDecrimentByOne()
		{
			InsertSizes1And2IntoRepo();
			var tss = GenerateNewTShirtSize3();
			_repository.AddTShirtSize(tss);
			_repository.Save();
			_repository.DeleteTShirtSize(tss);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllTShirtSizes().Count(), "One less t-shirt size should be present");
		}

		[TestMethod]
		public void TestDeleteTShirtSizeCausesRepoToReturnNullWhenItsIdIsRequested()
		{
			InsertSizes1And2IntoRepo();
			var tss = GenerateNewTShirtSize3();
			_repository.AddTShirtSize(tss);
			_repository.Save();
			_repository.DeleteTShirtSize(tss);
			_repository.Save();
			Assert.IsNull(_repository.GetTShirtSizeById(tss.id), "TShirt Size should not exist anymore");
		}

		[TestMethod]
		public void TestDeleteTShirtSizeWithIdCausesCountToDecrimentByOne()
		{
			InsertSizes1And2IntoRepo();
			var tss = GenerateNewTShirtSize3();
			_repository.AddTShirtSize(tss);
			_repository.Save();
			_repository.DeleteTShirtSize(tss.id);
			_repository.Save();
			Assert.AreEqual(2, _repository.GetAllTShirtSizes().Count(), "One less t-shirt size should exist");
		}

		[TestMethod]
		public void TestDeleteTShirtSizeWithIdCausesRepoToReturnNullWhenItsIdIsRequested()
		{
			InsertSizes1And2IntoRepo();
			var tss = GenerateNewTShirtSize3();
			_repository.AddTShirtSize(tss);
			_repository.Save();
			_repository.DeleteTShirtSize(tss.id);
			_repository.Save();
			Assert.IsNull(_repository.GetTShirtSizeById(tss.id), "TShirt Size should not exist anymore");
		}

		[TestMethod]
		public void TestInsertingThenDeletingThenInsertingTShirtSizesGeneratesDistinctIds()
		{
			var tss1 = GenerateNewTShirtSize1();
			var tss2 = GenerateNewTShirtSize2();
			_repository.AddTShirtSize(tss1);
			_repository.Save();
			_repository.DeleteTShirtSize(tss1);
			_repository.Save();
			_repository.AddTShirtSize(tss2);
			_repository.Save();
			Assert.AreNotEqual(tss1.id, tss2.id, "Should have generated distinct values");
		}
	}
}
