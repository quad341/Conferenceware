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
			//TODO: this should _NOT_ require trim, but on server 2008, hashes come out as 36 characters
			return MakePassword(toCheck) == password_hash.Trim();
		}

		public void SetPassword(string password)
		{
			seed = GenerateSeed();
			password_hash = MakePassword(password);
		}

		internal string MakePassword(string password)
		{
			var toHash = (STATIC_SEED + password + seed);
			return Sha1(toHash);
		}

		// from http://mattwilko.com/SHA1%20Hash%20in%20C#
		// his worked, mine didn't
		static string Sha1(string str)
		{
			byte[] buffer = Encoding.ASCII.GetBytes(str);
			var hasher = new SHA1CryptoServiceProvider();
			buffer = hasher.ComputeHash(buffer);
			var hash = new StringBuilder(40);
			for (var i = 0; i < buffer.Length; i++)
			{
				hash.Append(buffer[i].ToString("X"));
			}
			return hash.ToString();
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