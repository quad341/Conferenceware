using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Conferenceware.Models
{
    public class MechmaniaTeamMetadata
    {
        [Required]
        [StringLength(255)]
        [DisplayName("String Name")]
        public string team_name
        {
            get;
            set;
        }
        [Required]
        [Range(1,int.MaxValue)]
        [DisplayName("Team Member 1")]
        public int member1_id
        {
            get;
            set;
        }
        [Required]
        [Range(1, int.MaxValue)]
        [DisplayName("Team Member 2")]
        public int member2_id
        {
            get;
            set;
        }
        [Required]
        [Range(1, int.MaxValue)]
        [DisplayName("Team Member 3")]
        public int member3_id
        {
            get;
            set;
        }
        [Required]
        [StringLength(255)]
        [DisplayName("Account Name")]
        public string account_name
        {
            get;
            set;
        }
        [Required]
        [StringLength(255)]
        [DisplayName("Account Password")]
        public string account_password
        {
            get;
            set;
        }
    }
}
