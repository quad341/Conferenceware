using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Linq;
using xVal.ServerSide;

namespace Conferenceware.Models
{
	/// <summary>
	/// Partial class for convenience functions and validation of Location
	/// </summary>
	[MetadataType(typeof(LocationMetadata))]
	public partial class Location
	{
		/// <summary>
		/// Convenience property for building_name
		/// </summary>
		public string BuildingName
		{
			get
			{
				return building_name;
			}
			set
			{
				building_name = value;
			}
		}

		/// <summary>
		/// Convenience property for room_number
		/// </summary>
		public string RoomNumber
		{
			get
			{
				return room_number;
			}
			set
			{
				room_number = value;
			}
		}

		/// <summary>
		/// Convenience property for max_capacity
		/// </summary>
		public int MaxCapacity
		{
			get
			{
				return max_capacity;
			}
			set
			{
				max_capacity = value;
			}
		}

		/// <summary>
		/// Convenience property for notes
		/// </summary>
		public string Notes
		{
			get
			{
				return notes;
			}
			set
			{
				notes = value;
			}
		}

		/// <summary>
		/// Whether or not the model is valid
		/// </summary>
		 public bool IsValid 
         { 
             get 
             {
             	return !GetRuleViolations().Any();
             } 
         } 
  
		/// <summary>
		/// Gets the validation rule violations for the current model
		/// </summary>
		/// <returns>An enumeration of the errors</returns>
         public IEnumerable<ErrorInfo> GetRuleViolations () 
         { 
             return DataAnnotationsValidationRunner.GetErrors(this); 
         } 
  
		/// <summary>
		/// The method that is called on validation
		/// </summary>
		/// <param name="action">Ignored parameter for the interface</param>
         partial void OnValidate (ChangeAction action) 
         { 
             var errors = GetRuleViolations(); 
             if (errors.Any()) 
             { 
                 throw new RulesException(errors); 
             } 
         } 

	}
}