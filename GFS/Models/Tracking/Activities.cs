using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GFS.Models.Tracking
{
    public class Activities
    {
        [Key]
        [DisplayName("Activity ID")]
        public int activtyid { get; set; }

        [Required]
        [DisplayName("ID Number")]
        [StringLength(13, ErrorMessage = "ID No. Must Be 13 Digits Long", MinimumLength = 13)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter a valid ID No.")]
        public string userid { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]* {0,1}[a-zA-Z]*$", ErrorMessage = "Invalid First Name(s)")]
        [DisplayName("First Name(s)")]
        public string firstname { get; set; }
    
        [Required]
        [RegularExpression(@"^[a-zA-Z]* {0,1}[a-zA-Z]*$", ErrorMessage = "Invalid Last Name")]
        [DisplayName("Last Name")]
        public string lastname { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]* {0,1}[a-zA-Z]*$", ErrorMessage = "Invalid Last Name")]
        [DisplayName("Activity")]
        public string activity { get; set; }

        [DisplayName("Policy No")]
        public string policyNo { get; set; }

        [RegularExpression(@"^[a-zA-Z]* {0,1}[a-zA-Z]*$", ErrorMessage = "Member Name")]
        [DisplayName("Member name")]
        public string memname { get; set; }

        [Required]
        [DisplayName("Time of activity")]
        [DataType(DataType.DateTime)]
        public DateTime time { get; set; }
    }
}