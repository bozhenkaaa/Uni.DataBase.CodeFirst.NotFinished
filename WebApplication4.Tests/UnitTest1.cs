using Microsoft.EntityFrameworkCore;
using WebApplication4.models;

namespace WebApplication4.Tests;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Controllers;
using WebApplication4.Models.DTO;
using Xunit;


public class UnitTest1
{
    private static WebApplication4Context CreateContext()
    {
        var options = new DbContextOptionsBuilder<WebApplication4Context>().UseInMemoryDatabase(databaseName: "Lab").Options;
        WebApplication4Context abc = new WebApplication4Context(options);
        return abc;

    }

    [Fact]
    public async Task CreateClothes()
    {
        using var context = CreateContext();
        ClothesController c = new ClothesController(context);

        SubjectDtoWrite categ = new SubjectDtoWrite()
        {
            Cl_Category = 1,
            Cl_Color = "red",
            Cl_Fabric = "silk",
            Cl_Location = 1,
            Cl_Producer = 1,
            Cl_Quantity = 3,
            Cl_Seller = 1
        };
        
        var res = await ClothesController.PostClothes(categ);
        Assert.True(res.Result is RedirectToActionResult);

    }
    
}