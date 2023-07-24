using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication4.models
{
    public class Clothes
    {
        [Key]
        public int Cl_Id { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Category Id")]
        public int Cl_Category { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Prodecur Id")]
        public int Cl_Producer { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Fabric")]
        public string Cl_Fabric { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Color")]
        public string Cl_Color { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Quantity")]
        public int Cl_Quantity { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Seller Id")]
        public int Cl_Seller { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Location")]
        public int Cl_Location { get; set; }
        public virtual Category Category { get; set; }
        public virtual Location Location{ get; set; }
        public virtual Seller Seller { get; set; }
        public virtual Producer Producer { get; set; }

    }
}