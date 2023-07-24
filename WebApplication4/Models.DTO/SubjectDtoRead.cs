namespace WebApplication4.Models.DTO;

public class SubjectDtoRead
{
    public int Cl_Id { get; set; }
    
    public int Cl_Category { get; set; }
    
    public int Cl_Producer { get; set; }
    
    public string Cl_Fabric { get; set; }
    
    public string Cl_Color { get; set; }
    
    public int Price { get; set; }
    
    public int Cl_Quantity { get; set; }
    
    public int Cl_Seller { get; set; }
    
    public int Cl_Location { get; set; }
    public string Category { get; set; }
    public string Location  {get; set; }
    public string Seller { get; set; }
    public string Producer { get; set; }
}