using Microsoft.Build.Framework;

namespace WebApplication4.Models.DTO;

public class CategoryDtoWrite
{
    public CategoryDtoWrite()
    {
        Clothess = new List<int>();
    }
    
    
    [Required]
    public string Cat_Name {get;set; }
    [Required]
    public string Cat_Sex { get; set; }
    public virtual ICollection<int> Clothess { get; set; }
}