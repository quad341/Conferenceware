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
                People compare = obj as People;

                if (this._Attendee.Equals(compare._Attendee) &&
                    this._CompanyPerson.Equals(compare._CompanyPerson) &&
                    this._email == compare._email &&
                    this._id == compare._id &&
                    this._is_alum == compare._is_alum &&
                    this._name == compare._name &&
                    this._phone_number == compare._phone_number &&
                    this._Speaker.Equals(compare._Speaker) &&
                    this._StaffMember.Equals(compare._StaffMember) &&
                    this._Volunteer.Equals(compare._Volunteer))
                {
                    return true;
                }
            }

            return false;
        }
	}
}