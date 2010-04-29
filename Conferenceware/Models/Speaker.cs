using System;

namespace Conferenceware.Models
{
	public partial class Speaker : IEquatable<Speaker>
	{
		// linq will do most things here

		#region IEquatable<Speaker> Members

		public bool Equals(Speaker other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return other._person_id == _person_id;
		}

		#endregion

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(Speaker))
				return false;
			return Equals((Speaker)obj);
		}

		public override int GetHashCode()
		{
			return _person_id;
		}
	}
}