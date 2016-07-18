using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GFS.Models.Policies
{
    public class Policy
    {
        [Key]
        [Required]
        [DisplayName("Policy No")]
        public string policyNo { get; set; }

        public string Policyplan { get; set; }

        public double Premium { get; set; }

        public string SalesPerson { get; set; }

        public DateTime dateAdded { get; set; }
    }
}