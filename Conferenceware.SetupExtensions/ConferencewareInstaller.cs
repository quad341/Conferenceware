using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Conferenceware.Models;

namespace Conferenceware.SetupExtensions
{
	[RunInstaller(true)]
	public class ConferencewareInstaller : Installer
	{
		ConferencewareInstaller()
			: base()
		{
			// no more to do
		}

		public override void Install(System.Collections.IDictionary stateSaver)
		{
			base.Install(stateSaver);
			// now show thing for adding database
			var conn = new SqlConnection("Data Source=(local);Initial Catalog=Conferenceware;Integrated Security=True");
			ExecuteSql(conn, "generate_database.sql");
			var username = Context.Parameters["UserName"];
			var password = Context.Parameters["Password"];
			AddUser(username, password, conn);
		}

		private void AddUser(string username, string password, SqlConnection sqlCon)
		{
			var person = new People
							{
								email = "admin@local.com",
								name = "Admin",
								phone_number = "555-555-5555"
							};
			var sm = new StaffMember
						{
							auth_name = username,
							People = person
						};
			sm.SetPassword(password);
			var repo = new ConferencewareRepository(sqlCon.ConnectionString);
			repo.AddStaffMember(sm);
			repo.Save();
		}

		// from http://www.codeproject.com/KB/install/sqlscriptinstall.aspx
		private static string GetScript(string name)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			Stream str = asm.GetManifestResourceStream(
							asm.GetName().Name + "." + name);
			var reader = new StreamReader(str);
			return reader.ReadToEnd();
		}
		private static void ExecuteSql(SqlConnection sqlCon, string scriptName)
		{
			var regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);

			string txtSql = GetScript(scriptName);
			string[] sqlLine = regex.Split(txtSql);

			SqlCommand cmd = sqlCon.CreateCommand();
			cmd.Connection = sqlCon;

			foreach (string line in sqlLine)
			{
				if (line.Length > 0)
				{
					cmd.CommandText = line;
					cmd.CommandType = CommandType.Text;
					try
					{
						cmd.ExecuteNonQuery();
					}
					catch (SqlException)
					{
						//rollback
						ExecuteSql(sqlCon, "kill_database.sql");
						break;
					}
				}
			}
		}
	}
}
