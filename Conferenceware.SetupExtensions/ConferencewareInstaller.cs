using System.ComponentModel;
using System.Configuration.Install;
using System.Windows.Forms;
using Conferenceware.Models;

namespace Conferenceware.SetupExtensions
{
	[RunInstaller(true)]
	public class ConferencewareInstaller : Installer
	{
		private const string ConnString = "Data Source=(local);Initial Catalog=Conferenceware;Integrated Security=True";
		public override void Install(System.Collections.IDictionary stateSaver)
		{
			base.Install(stateSaver);
			// now show thing for adding database
			var username = Context.Parameters["UserName"];
			var password = Context.Parameters["Password"];
			var message = "User successfully added";
			if (username == null || password == null)
			{
				message = "Using admin/password for authentication";
				username = "admin";
				password = "password";
			}
			InstallDbAndAddUser(username, password, ConnString);
			MessageBox.Show(message);
		}

		public override void Uninstall(System.Collections.IDictionary savedState)
		{
			base.Uninstall(savedState);
			RemoveDb(ConnString);
		}

		private static void RemoveDb(string connString)
		{
			var repo = new ConferencewareRepository(connString);
			repo.DeleteDatabase();
		}

		private static void InstallDbAndAddUser(string username, string password, string connString)
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
			var repo = new ConferencewareRepository(connString);
			if (repo.DatabaseExists())
			{
				repo.DeleteDatabase();
			}
			repo.CreateDatabase();
			repo.AddStaffMember(sm);
			repo.Save();
		}
	}
}
