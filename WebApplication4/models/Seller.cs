using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication4.models
{
    public class Seller
    {
        public Seller()
        {
            Clothess = new List<Clothes>();
        }
        [Key]
        public int S_Id { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Name")]
        public string S_Name { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Phone Number")]
        public string S_Phone { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "City")]
        public string S_City { get; set; }

        public virtual ICollection<Clothes> Clothess { get; set; }
    }
}