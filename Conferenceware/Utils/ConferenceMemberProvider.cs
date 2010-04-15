using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Conferenceware.Models;

namespace Conferenceware.Utils
{
	/// <summary>
	/// Class that authenticates staff members when logging into Conferenceware
	/// </summary>
	public class ConferenceMemberProvider : System.Web.Security.MembershipProvider
	{
		private readonly IRepository _repository;
		public ConferenceMemberProvider()
		{
			_repository = new ConferencewareRepository();
		}
		/// <summary>
		/// Validates a user based on password
		/// </summary>
		/// <param name="username">Username of staff member</param>
		/// <param name="password">Password of staff member</param>
		/// <returns>True iff username is found and password matches the one in the database. False otherwise</returns>
		public override bool ValidateUser(string username, string password)
		{
			// No blank passwords
			if (string.IsNullOrEmpty(password.Trim()))
			{
				return false;
			}
			// Find the staff member
			var staffmember = _repository.GetAllStaffMembers().SingleOrDefault(x => x.auth_name == username);
			// If no staff member found with this name, false
			if (staffmember == null)
			{
				return false;
			}
			// TODO: Actually check passwords
			return true;
			//return false;
		}

		// Everything below is not implemented because we don't use it (it just makes the compiler happy to have it)
		public override string ApplicationName
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override bool ChangePassword(string username, string oldPassword, string newPassword)
		{
			throw new NotImplementedException();
		}

		public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
		{
			throw new NotImplementedException();
		}

		public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
		{
			throw new NotImplementedException();
		}

		public override bool DeleteUser(string username, bool deleteAllRelatedData)
		{
			throw new NotImplementedException();
		}

		public override bool EnablePasswordReset
		{
			get { throw new NotImplementedException(); }
		}

		public override bool EnablePasswordRetrieval
		{
			get { throw new NotImplementedException(); }
		}

		public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override int GetNumberOfUsersOnline()
		{
			throw new NotImplementedException();
		}

		public override string GetPassword(string username, string answer)
		{
			throw new NotImplementedException();
		}

		public override MembershipUser GetUser(string username, bool userIsOnline)
		{
			throw new NotImplementedException();
		}

		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
		{
			throw new NotImplementedException();
		}

		public override string GetUserNameByEmail(string email)
		{
			throw new NotImplementedException();
		}

		public override int MaxInvalidPasswordAttempts
		{
			get { return 10; }
		}

		public override int MinRequiredNonAlphanumericCharacters
		{
			get { return 0; }
		}

		public override int MinRequiredPasswordLength
		{
			get { return 8; }
		}

		public override int PasswordAttemptWindow
		{
			get { throw new NotImplementedException(); }
		}

		public override MembershipPasswordFormat PasswordFormat
		{
			get { throw new NotImplementedException(); }
		}

		public override string PasswordStrengthRegularExpression
		{
			get { throw new NotImplementedException(); }
		}

		public override bool RequiresQuestionAndAnswer
		{
			get { throw new NotImplementedException(); }
		}

		public override bool RequiresUniqueEmail
		{
			get { throw new NotImplementedException(); }
		}

		public override string ResetPassword(string username, string answer)
		{
			throw new NotImplementedException();
		}

		public override bool UnlockUser(string userName)
		{
			throw new NotImplementedException();
		}

		public override void UpdateUser(MembershipUser user)
		{
			throw new NotImplementedException();
		}
	}
}
