namespace WebApplication4.Models.DTO;

public class CategoryDtoRead
{
    public CategoryDtoRead()
    {
        Clothess = new List<string>();
    }
    public int Cat_Id { get; set; }
    public string Cat_Name {get;set; }
    
    public string Cat_Sex { get; set; }
    public virtual ICollection<string> Clothess { get; set; }
}