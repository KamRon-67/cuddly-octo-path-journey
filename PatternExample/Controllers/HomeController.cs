using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PatternExample.Database;
using PatternExample.Models;
using PatternExample.Models.Attributes;

namespace PatternExample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Demo()
    {

        var list = new List<DataFromDBCall>
        {
           new DataFromDBCall{ Name = "Object1", Description = "Des" },
           new DataFromDBCall{ Name = "Object2", Description = "Des" },
           new DataFromDBCall{ Name = "Object3", Description = ""}
        };

        var searchModelEx = new DemoSearchModel { Description = "Des" };

        var query = list.AsQueryable();

        query = ApplySearchFilters(query, searchModelEx);

        var result = query.ToList();

        return View();
    }


    private IQueryable<DataFromDBCall> ApplySearchFilters(IQueryable<DataFromDBCall> query, DemoSearchModel searchModel)
    {
        foreach (var property in searchModel.GetType().GetProperties())
        {
            var attribute = Attribute.GetCustomAttribute(property, typeof(DemoFilterAttribute));
            if(attribute != null && attribute is DemoFilterAttribute filterAttribute)
            {
                var value = property.GetValue(searchModel);
                if (value is not null)
                {
                    query = DemoExpressions.Filter[filterAttribute._fieldType].Invoke(query, searchModel);
                }
            }
        }
        return query;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

