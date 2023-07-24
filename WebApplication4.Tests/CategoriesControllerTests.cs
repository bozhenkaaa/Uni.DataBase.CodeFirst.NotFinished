namespace WebApplication4.Tests;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Controllers;
using Xunit;

public class CategoriesControllerTests
{
    [Fact]
    public void IndexViewResultNotNull()
    {
        using var cont = CreateContext();
        CategoriesController c = new CategoriesController(cont);
        

    }
}