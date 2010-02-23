using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
	[MetadataType(typeof(TShirtSizeMetadata))]
	public partial class TShirtSize
	{
		//linq takes care of the rest
		public override string ToString()
		{
			return name;
		}
	}
}