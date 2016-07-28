using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GFS.Domain.Entities
{
    public class Claims
    {
        [Required]
        public int claimno { get; set; }

        [Required(ErrorMessage = "Please enter policy number")]
        public string polNo { get; set; }

        [Required(ErrorMessage = "Please enter ID number")]
        [StringLength(13, ErrorMessage = "ID No. Must Be 13 Digits Long", MinimumLength = 13)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter valid ID No.")]
        public string idNo { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Names { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Please pick a date and time")]
        [DataType(DataType.Time)]
        public DateTime datetime { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        [Display(Name = "Line 1")]
        public string Line1 { get; set; }
        [Display(Name = "Line 2")]
        public string Line2 { get; set; }
        [Display(Name = "Line 3")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        public DateTime claimdate { get; set; }
    }
}
