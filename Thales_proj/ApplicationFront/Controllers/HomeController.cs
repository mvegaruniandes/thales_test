using ApplicationFront.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using System.Diagnostics;

namespace ApplicationFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GetEmployees _apiEmployees;
        private readonly GetEmployeeById _apiEmployee;


        public HomeController(ILogger<HomeController> logger, GetEmployees apiEmployees, GetEmployeeById apiEmployee)
        {
            _logger = logger;
            _apiEmployees = apiEmployees;
            _apiEmployee = apiEmployee;
        }

        public IActionResult Index()
        {
            // Realizar la llamada a la API y obtener los datos
            var apiData = _apiEmployees.GetEmployeesAsync();

            if (apiData.data == null)
            {
                var viewModel = new ErrorViewModel
                {
                    ErrorMessage = apiData.message
                };

                return View("Error", viewModel);
            }

            // Enviar los datos a la vista
            return View(apiData);
        }

        public ActionResult Search(int? id)
        {
            var apiData = new EmployeesDTO();

            if (id != null)
            {
                apiData = _apiEmployee.GetEmployeeByIdAsync(id);
            }
            else
            {
                apiData = _apiEmployees.GetEmployeesAsync();
            }

            if (apiData.data == null)
            {
                var viewModel = new ErrorViewModel
                {
                    ErrorMessage = apiData.message
                };

                return View("Error", viewModel);
            }

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