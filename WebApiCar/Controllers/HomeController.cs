using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApiCar.Models;
using WebApiCar.Service;
using WebApiCar.ViewsModels;

namespace WebApiCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;

        public HomeController ( ILogger<HomeController> logger,ICarService carService)
        {
            _logger = logger;
            _carService = carService;
            

        }

        public IActionResult Index ()
        {
            _carService.Upload(@"C:\Users\Admin\source\repos\.ASPNET\Modul_2_3\WebApiCar\WebApiCar\DataCar.txt");
            _carService.ConverToCars();
            var ViewModel  = new IndexModel()
            {
                Cars = _carService.GetCars(),
            };
            return View(ViewModel);
        }

        public IActionResult Privacy ()
        {
            return View();
        }

        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error ()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}