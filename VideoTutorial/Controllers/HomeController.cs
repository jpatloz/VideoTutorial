using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoTutorial.Models;

namespace VideoTutorial.Controllers
{
    public class HomeController : Controller
    {

        public VideoTutorial.Models.VideoTutorial4Context db = new VideoTutorial4Context();

        private readonly IHttpContextAccessor contxt;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            contxt = httpContextAccessor;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Lista de Empleados";

            var empleados = db.Empleados.ToList();

            return View(empleados);
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
