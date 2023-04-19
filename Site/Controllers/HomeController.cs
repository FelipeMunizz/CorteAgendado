using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Site.Models;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Barbearia barbearia = new Barbearia();
            barbearia.BarbeariaId = 1;

            string url = $"http://localhost:5241/api/Barbearia/{barbearia.BarbeariaId}";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var jsonResult = await response.Content.ReadAsStringAsync();
            JObject obj = JObject.Parse(jsonResult);
            barbearia.Nome = (string)obj["nome"];
            return View(barbearia);
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