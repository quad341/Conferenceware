using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

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
			SqlCommand cmd = sqlCon.CreateCommand();
			cmd.Connection = sqlCon;
			cmd.CommandText = @"INSERT INTO People (name, email, phone_number) VALUES ('name','email@email.edu', '555-555-5555')";
			cmd.CommandType = CommandType.Text;
			cmd.ExecuteNonQuery();
			cmd.CommandText = @"INSERT INTO StaffMembers (person_id, auth_name) VALUES (1,'" + username + "')";
			cmd.CommandType = CommandType.Text;
			cmd.ExecuteNonQuery();
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
