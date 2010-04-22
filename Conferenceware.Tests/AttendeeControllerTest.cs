using Conferenceware.Controllers;
using Conferenceware.Models;
using Conferenceware.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;


namespace Conferenceware.Tests
{
    
    
    /// <summary>
    ///This is a test class for AttendeeControllerTest and is intended
    ///to contain all AttendeeControllerTest Unit Tests
    ///</summary>
	[TestClass()]
	public class AttendeeControllerTest
	{
        IRepository _repository;
        Attendee attendee1;

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

        public void Initialize()
        {
            _repository = new TestRepository();

            attendee1 = new Attendee
            {
                person_id = 1,
                People = new People
                {
                    name = "John Dickface",
                    phone_number = "309-867-5309",
                    is_alum = false,
                    email = "dickface.dickface@dickface.com"
                },
                tshirt_id = 1,
                food_choice_id = 1
            };

        }

		/// <summary>
		///A test for AttendeeController Constructor
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("ConferenceWare Attendee", "C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware")]
		[UrlToTest("http://localhost:51176/Attendee/")]
		public void AttendeeControllerConstructorTest()
		{
			IRepository repo = _repository;
			AttendeeController target = new AttendeeController(repo);
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for AttendeeController Constructor
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/Attendee")]
		public void AttendeeControllerConstructorTest1()
		{
			AttendeeController target = new AttendeeController();
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for Create
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		/*[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/Attendee/Create")]*/
		public void CreateTest()
		{
            Initialize();
			AttendeeController target = new AttendeeController(_repository);
			FormCollection collection = ConvertAttendeeToFormCollection(attendee1);
			ActionResult expected = new RedirectToRouteResult(String.Empty, new RouteValueDictionary());
			ActionResult actual = target.Create(collection);

			IQueryable<Attendee> attendeeList = _repository.GetAllAttendees();
			Assert.IsTrue(attendeeList.Contains(attendee1));
		}

		/// <summary>
		///A test for Create
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void CreateTest1()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Create();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Delete
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		/*[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]*/
		public void DeleteTest()
		{
			AttendeeController target = new AttendeeController(_repository); // TODO: Initialize to an appropriate value
			int id = 0; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Delete(id);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Edit
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void EditTest()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			int id = 0; // TODO: Initialize to an appropriate value
			FormCollection collection = null; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Edit(id, collection);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Edit
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void EditTest1()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			int id = 0; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Edit(id);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Index
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void IndexTest()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Index();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for MakeEditDateFromAttendee
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		[DeploymentItem("Conferenceware.dll")]
		public void MakeEditDateFromAttendeeTest()
		{
			AttendeeController_Accessor target = new AttendeeController_Accessor(); // TODO: Initialize to an appropriate value
			Attendee attendee = null; // TODO: Initialize to an appropriate value
			AttendeeEditData expected = null; // TODO: Initialize to an appropriate value
			AttendeeEditData actual;
			actual = target.MakeEditDateFromAttendee(attendee);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		private FormCollection ConvertAttendeeToFormCollection(Attendee attendee)
		{
			var fc = new FormCollection();
			fc.Add("person_id", attendee.person_id.ToString());
			fc.Add("People_name", attendee.People.name);
			fc.Add("People_email", attendee.People.email);
			fc.Add("People_phone_number", attendee.People.phone_number.ToString());
			fc.Add("tshirt_id", attendee.tshirt_id.ToString());
			fc.Add("food_choice_id", attendee.food_choice_id.ToString());
			fc.Add("People_is_alum", attendee.People.is_alum.ToString());
			return fc;
		}

		/// <summary>
		///A test for AttendeeController Constructor
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void AttendeeControllerConstructorTest2()
		{
			IRepository repo = null; // TODO: Initialize to an appropriate value
			AttendeeController target = new AttendeeController(repo);
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for AttendeeController Constructor
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void AttendeeControllerConstructorTest3()
		{
			AttendeeController target = new AttendeeController();
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for Create
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void CreateTest2()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			FormCollection collection = null; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Create(collection);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Create
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void CreateTest3()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Create();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Delete
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void DeleteTest1()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			int id = 0; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Delete(id);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Edit
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void EditTest2()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			int id = 0; // TODO: Initialize to an appropriate value
			FormCollection collection = null; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Edit(id, collection);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Edit
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void EditTest3()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			int id = 0; // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Edit(id);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Index
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		public void IndexTest1()
		{
			AttendeeController target = new AttendeeController(); // TODO: Initialize to an appropriate value
			ActionResult expected = null; // TODO: Initialize to an appropriate value
			ActionResult actual;
			actual = target.Index();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for MakeEditDateFromAttendee
		///</summary>
		// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
		// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
		// whether you are testing a page, web service, or a WCF service.
		[TestMethod()]
		[HostType("ASP.NET")]
		[AspNetDevelopmentServerHost("C:\\Users\\Nicholas\\Documents\\Visual Studio 2010\\Projects\\Conferenceware\\Conferenceware", "/")]
		[UrlToTest("http://localhost:51176/")]
		[DeploymentItem("Conferenceware.dll")]
		public void MakeEditDateFromAttendeeTest1()
		{
			AttendeeController_Accessor target = new AttendeeController_Accessor(); // TODO: Initialize to an appropriate value
			Attendee attendee = null; // TODO: Initialize to an appropriate value
			AttendeeEditData expected = null; // TODO: Initialize to an appropriate value
			AttendeeEditData actual;
			actual = target.MakeEditDateFromAttendee(attendee);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
