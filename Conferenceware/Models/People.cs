using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	[MetadataType(typeof(PeopleMetadata))]
	public partial class People
	{
		//linq is doing the rest
		public bool Equals(object obj)
		{
			if (obj is People)
			{
				var compare = obj as People;

				if (_Attendee.Equals(compare._Attendee) &&
					_CompanyPerson.Equals(compare._CompanyPerson) &&
					_email == compare._email &&
					_id == compare._id &&
					_is_alum == compare._is_alum &&
					_name == compare._name &&
					_phone_number == compare._phone_number &&
					_Speaker.Equals(compare._Speaker) &&
					_StaffMember.Equals(compare._StaffMember) &&
					_Volunteer.Equals(compare._Volunteer))
				{
					return true;
				}
			}

			return false;
		}
	}
}