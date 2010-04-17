using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conferenceware;
using Conferenceware.Controllers;
using Conferenceware.Models;

namespace Conferenceware.Tests.Controllers
{

	[TestClass]
	public class AccountControllerTest
	{

		[TestMethod]
		public void LogOff_LogsOutAndRedirects()
		{
			// Arrange
			AccountController controller = GetAccountController();

			// Act
			ActionResult result = controller.LogOff();

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
			RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
			Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
			Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
			Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignOut_WasCalled);
		}

		[TestMethod]
		public void LogOn_Get_ReturnsView()
		{
			// Arrange
			AccountController controller = GetAccountController();

			// Act
			ActionResult result = controller.LogOn();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod]
		public void LogOn_Post_ReturnsRedirectOnSuccess_WithoutReturnUrl()
		{
			// Arrange
			AccountController controller = GetAccountController();
			LogOnModel model = new LogOnModel()
			{
				UserName = "someUser",
				Password = "goodPassword",
				RememberMe = false
			};

			// Act
			ActionResult result = controller.LogOn(model, null);

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
			RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
			Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
			Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
			Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
		}

		[TestMethod]
		public void LogOn_Post_ReturnsRedirectOnSuccess_WithReturnUrl()
		{
			// Arrange
			AccountController controller = GetAccountController();
			LogOnModel model = new LogOnModel()
			{
				UserName = "someUser",
				Password = "goodPassword",
				RememberMe = false
			};

			// Act
			ActionResult result = controller.LogOn(model, "/someUrl");

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectResult));
			RedirectResult redirectResult = (RedirectResult)result;
			Assert.AreEqual("/someUrl", redirectResult.Url);
			Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
		}

		[TestMethod]
		public void LogOn_Post_ReturnsViewIfModelStateIsInvalid()
		{
			// Arrange
			AccountController controller = GetAccountController();
			LogOnModel model = new LogOnModel()
			{
				UserName = "someUser",
				Password = "goodPassword",
				RememberMe = false
			};
			controller.ModelState.AddModelError("", "Dummy error message.");

			// Act
			ActionResult result = controller.LogOn(model, null);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.AreEqual(model, viewResult.ViewData.Model);
		}

		[TestMethod]
		public void LogOn_Post_ReturnsViewIfValidateUserFails()
		{
			// Arrange
			AccountController controller = GetAccountController();
			LogOnModel model = new LogOnModel()
			{
				UserName = "someUser",
				Password = "badPassword",
				RememberMe = false
			};

			// Act
			ActionResult result = controller.LogOn(model, null);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.AreEqual(model, viewResult.ViewData.Model);
			Assert.AreEqual("The user name or password provided is incorrect.", controller.ModelState[""].Errors[0].ErrorMessage);
		}

		[TestMethod]
		public void OnActionExecuting_SetsViewData()
		{
			// Arrange
			AccountController controller = GetAccountController();

			// Act
			((IActionFilter)controller).OnActionExecuting(null);

			// Assert
			Assert.AreEqual(10, controller.ViewData["PasswordLength"]);
		}

		private static AccountController GetAccountController()
		{
			AccountController controller = new AccountController(new MockFormsAuthenticationService(), new MockMembershipService());
			controller.ControllerContext = new ControllerContext()
			{
				Controller = controller,
				RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
			};
			return controller;
		}

		private class MockFormsAuthenticationService : IFormsAuthenticationService
		{
			public bool SignIn_WasCalled;
			public bool SignOut_WasCalled;

			public void SignIn(string userName, bool createPersistentCookie)
			{
				// verify that the arguments are what we expected
				Assert.AreEqual("someUser", userName);
				Assert.IsFalse(createPersistentCookie);

				SignIn_WasCalled = true;
			}

			public void SignOut()
			{
				SignOut_WasCalled = true;
			}
		}

		private class MockHttpContext : HttpContextBase
		{
			private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);

			public override IPrincipal User
			{
				get
				{
					return _user;
				}
				set
				{
					base.User = value;
				}
			}
		}

		private class MockMembershipService : IMembershipService
		{
			public int MinPasswordLength
			{
				get { return 10; }
			}

			public bool ValidateUser(string userName, string password)
			{
				return (userName == "someUser" && password == "goodPassword");
			}

			public MembershipCreateStatus CreateUser(string userName, string password, string email)
			{
				if (userName == "duplicateUser")
				{
					return MembershipCreateStatus.DuplicateUserName;
				}

				// verify that values are what we expected
				Assert.AreEqual("goodPassword", password);
				Assert.AreEqual("goodEmail", email);

				return MembershipCreateStatus.Success;
			}

			public bool ChangePassword(string userName, string oldPassword, string newPassword)
			{
				return (userName == "someUser" && oldPassword == "goodOldPassword" && newPassword == "goodNewPassword");
			}
		}

	}
}
