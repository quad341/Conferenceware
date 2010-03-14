using System;
using System.Collections.Generic;

namespace Conferenceware.Models
{
	public class SpeakerComparitor : IEqualityComparer<Speaker>
	{
		public bool Equals(Speaker x, Speaker y)
		{
			return x.person_id == y.person_id;
		}

		public int GetHashCode(Speaker obj)
		{
			return obj.person_id.GetHashCode();
		}
	}
}