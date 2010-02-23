using System.ComponentModel.DataAnnotations;
using System.Linq;
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
		[TestMethod]
		public void TestBuildingNameIsRequired()
		{
			var propertyInfo =
				PropertyDescriptorExtractor.GetPropertyInfo(typeof (Location)).SingleOrDefault(
					p => p.Name == "building_name");
			var attribute = propertyInfo.Attributes.OfType<RequiredAttribute>().FirstOrDefault();
			Assert.IsNotNull(attribute);
		}

		[TestMethod]
		public void TestBuildingNameHasStringLengthLimit()
		{
			var propertyInfo =
				PropertyDescriptorExtractor.GetPropertyInfo(typeof(Location)).SingleOrDefault(
					p => p.Name == "building_name");
			var attribute =
				propertyInfo.Attributes.OfType<StringLengthAttribute>().FirstOrDefault();
			Assert.IsNotNull(attribute.MaximumLength);
		}


		[TestMethod]
		public void TestBuildingNameMustBeLessThan255Characters()
		{
			var propertyInfo =
				PropertyDescriptorExtractor.GetPropertyInfo(typeof (Location)).SingleOrDefault(
					p => p.Name == "building_name");
			var attribute =
				propertyInfo.Attributes.OfType<StringLengthAttribute>().FirstOrDefault();
			Assert.AreEqual(255, attribute.MaximumLength);
		}

		[TestMethod]
		public void TestRoomNumberIsRequired()
		{
			var propertyInfo =
				PropertyDescriptorExtractor.GetPropertyInfo(typeof (Location)).SingleOrDefault(
					p => p.Name == "room_number");
			var attribute =
				propertyInfo.Attributes.OfType<RequiredAttribute>().FirstOrDefault();
			Assert.IsNotNull(attribute);
		}

		[TestMethod]
		public void TestRoomNumberHasStringLengthLimit()
		{
			var propertyInfo =
				PropertyDescriptorExtractor.GetPropertyInfo(typeof (Location)).SingleOrDefault(
					p => p.Name == "room_number");
			var attribute =
				propertyInfo.Attributes.OfType<StringLengthAttribute>().FirstOrDefault();
			Assert.IsNotNull(attribute);
		}

		[TestMethod]
		public void TestRoomNumberHasStringLengthLimitOf255()
		{
			var propertyInfo =
				PropertyDescriptorExtractor.GetPropertyInfo(typeof (Location)).SingleOrDefault(
					p => p.Name == "room_number");
			var attribute =
				propertyInfo.Attributes.OfType<StringLengthAttribute>().FirstOrDefault();
			Assert.AreEqual(255, attribute.MaximumLength);
		}

		[TestMethod]
		public void TestMaxCapacityHasRangeRestriction()
		{
			var propertyInfo =
				PropertyDescriptorExtractor.GetPropertyInfo(typeof (Location)).SingleOrDefault(
					p => p.Name == "max_capacity");
			var attribute =
				propertyInfo.Attributes.OfType<RangeAttribute>().FirstOrDefault();
			Assert.IsNotNull(attribute);
		}

		[TestMethod]
		public void TestMaxCapacityHasRangeRestrictionOf1ToMaxInt()
		{
			var propertyInfo =
				PropertyDescriptorExtractor.GetPropertyInfo(typeof (Location)).SingleOrDefault(
					p => p.Name == "max_capacity");
			var attribute =
				propertyInfo.Attributes.OfType<RangeAttribute>().FirstOrDefault();
			Assert.AreEqual(1, attribute.Minimum);
			Assert.AreEqual(int.MaxValue, attribute.Maximum);
		}

		[TestMethod]
		public void TestNotesAreNotRequired()
		{
			var propertyInfo =
				PropertyDescriptorExtractor.GetPropertyInfo(typeof (Location)).SingleOrDefault(p => p.Name == "notes");
			var attribute =
				propertyInfo.Attributes.OfType<RequiredAttribute>().FirstOrDefault();
			Assert.IsNull(attribute);
		}
	}
}
