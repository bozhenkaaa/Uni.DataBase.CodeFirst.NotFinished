using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication4.models
{
    public class Producer
    {
        public Producer()
        {
            Clothess = new List<Clothes>();
        }
        [Key]
        public int Pr_Id { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Producer Name")]
        public string Pr_Name { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Producer Country")]
        public string Pr_Country { get; set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Years of working")]
        public int Pr_Years { get; set; }
        public virtual ICollection<Clothes> Clothess { get; set; }
    }
}