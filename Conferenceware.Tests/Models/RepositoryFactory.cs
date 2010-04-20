using Conferenceware.Models;

namespace Conferenceware.Tests.Models
{
	public class RepositoryFactory
	{
		private const bool _testRepo = true;

		private const string _connString = "Data Source=(local);Initial Catalog=Conferenceware;Integrated Security=True";

		public static IRepository GetRepo()
		{
			if (_testRepo)
			{
				return new TestRepository();
			}
			return new ConferencewareRepository(_connString);
		}
	}
}