using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	[MetadataType(typeof(FoodMetadata))]
	public partial class Food
	{
		//linq does the rest
		public override string ToString()
		{
			return name;
		}
	}
}