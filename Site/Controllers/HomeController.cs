using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Site.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly string urlBase = "http://localhost:5241/api/Barbearia";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Barbearia barbearia = new Barbearia();
            barbearia.BarbeariaId = 1;

            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{urlBase}/{barbearia.BarbeariaId}");
            var jsonResult = await response.Content.ReadAsStringAsync();
            JObject obj = JObject.Parse(jsonResult);
            barbearia.Nome = (string)obj["nome"];
            return View(barbearia);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Barbearia barbearia)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpClient client = new HttpClient();
                var barber = new Barbearia { Nome = barbearia.Nome };

                var content = new StringContent(JsonConvert.SerializeObject(barber), Encoding.UTF8, "application/json");
                response = await client.PostAsync($"{urlBase}/Cadastrar", content);
                if (!response.IsSuccessStatusCode)
                {
                    TempData["MensagemErro"] = "Não Foi possivel cadastrar a barbearia";
                    return View();
                }
                TempData["MensagemSucesso"] = "Barbearia cadastrada com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}