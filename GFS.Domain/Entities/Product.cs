using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GFS.Domain.Entities
{
    public class Product
    {
        [Key]
        [Display(Name = "ID")]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string category { get; set; }

        //[Display(Name = "Picture")]
        //public string albumArtUrl { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
