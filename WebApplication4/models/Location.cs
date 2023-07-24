using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication4.models
{
    public class Location
    {
        public Location()
        {
            Clothess = new List<Clothes>();
        }
        [Key]
        public int L_Id { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Location Name")]
        public string L_Name { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "City")]
        public string L_City { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Address")]
        public string L_Address { get; set; }



        public virtual ICollection<Clothes> Clothess { get; set; }
    }
}