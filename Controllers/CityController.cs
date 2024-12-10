using ConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeAPI.Controllers
{
    public class CityController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7104/api/City");
        private readonly HttpClient _client;
        public CityController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GET()
        {
            List<CityModel> city = new List<CityModel>();
            HttpResponseMessage response = _client.GetAsync(baseAddress).Result;
            if (response .IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                city = JsonConvert.DeserializeObject<List<CityModel>>(data);
            }
            return View("CityList", city);
        }
    }
}
