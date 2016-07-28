using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GFS.Domain.Entities
{
    public class Product
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        [Display(Name = "Category")]
        public string category { get; set; }

        //[Display(Name = "Picture")]
        //public string albumArtUrl { get; set; }

        [Required(ErrorMessage = "Please specify quantity on hand")]
        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a suppliers name")]
        [Display(Name = "Supplier")]
        public string supplier { get; set; }

        [Display(Name = "Date Added")]
        public DateTime dateadded { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
