using ApplicationFront.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApplicationFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService _apiService;


        public HomeController(ILogger<HomeController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            // Realizar la llamada a la API y obtener los datos
            var apiData = _apiService.GetEmployeesAsync();

            // Enviar los datos a la vista
            return View(apiData);
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
}