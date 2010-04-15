using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Conferenceware.Models
{
	[MetadataType(typeof(StaffMemberMetadata))]
	public partial class StaffMember
	{
		// yay linq
		private const string STATIC_SEED = "xyzzyafeafaen12$";

		public bool VerifyPassword(string toCheck)
		{
			return MakePassword(toCheck) == password_hash;
		}

		public void SetPassword(string password)
		{
			seed = GenerateSeed();
			password_hash = MakePassword(password);
		}

		private string MakePassword(string password)
		{
			var sha = SHA1.Create();
			var toHash = Encoding.Unicode.GetBytes(STATIC_SEED + password + seed);
			return Convert.ToBase64String(sha.ComputeHash(toHash, 0, toHash.Length));
		}

		private string GenerateSeed()
		{
			return RandomString(10, false);
		}

		//from http://www.c-sharpcorner.com/UploadFile/mahesh/RandomNumber11232005010428AM/RandomNumber.aspx
		/// <summary>
		/// Generates a random string with the given length
		/// </summary>
		/// <param name="size">Size of the string</param>
		/// <param name="lowerCase">If true, generate lowercase string</param>
		/// <returns>Random string</returns>
		private string RandomString(int size, bool lowerCase)
		{
			var builder = new StringBuilder();
			var random = new Random();
			for (int i = 0; i < size; i++)
			{
				char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				builder.Append(ch);
			}
			if (lowerCase)
				return builder.ToString().ToLower();
			return builder.ToString();
		}
	}


}