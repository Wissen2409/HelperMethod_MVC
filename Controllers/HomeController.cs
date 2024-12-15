using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HelperMethod_MVC.Models;
using Helpers;
using System.Linq.Expressions;

namespace HelperMethod_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {

        List<Ogrenci> ogr = new List<Ogrenci>();
        ogr.Add(new Ogrenci() { Name = "Hamdi" });
        ogr.Add(new Ogrenci() { Name = "Ali" });
        ogr.Add(new Ogrenci() { Name = "Oğuz" });

        _logger = logger;
        string a = "merhaba ben string bir değerim";
        string value = a.Reverse();


        Random rnd = new Random();
        string randomString = rnd.NextString(10);

        #region Expression Örnek
        // Expression örneği : sayıyı 2 ile çarpan bir expression örneği yapalım!!!
        Expression<Func<int, int>> doubleExpression = x => x * 2;
        // oluşturduğumnuz Expression'u çalığtıralım!!

        Func<int, int> doubleFunc = doubleExpression.Compile();

        int result = doubleFunc(10);
        // Koleksiyon içerisinden adı hamdi olan öğrenciyi bulan expression
        Expression<Func<Ogrenci, bool>> ogrenciExpression = x => x.Name == "Hamdi";
        Func<Ogrenci, bool> ogrenciFunc = ogrenciExpression.Compile();

       var selectedOgrenci =  ogr.Where(ogrenciFunc).FirstOrDefault();


        #endregion
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
