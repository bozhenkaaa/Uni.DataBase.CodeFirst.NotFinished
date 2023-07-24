using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.models
{
    public class Category
    {
        public Category()
        {
            Clothess = new List<Clothes>();
        }
        [Key]
        public int Cat_Id { get; set; }
        [Required(ErrorMessage="Can not be empty")]
        [Display(Name ="Clothes Type")]
        public string Cat_Name {get;set; }
        [Required(ErrorMessage = "Can not be empty")]
        [Display(Name = "Sex")]
        public string Cat_Sex { get; set; }
        public virtual ICollection<Clothes> Clothess { get; set; }
    }
}