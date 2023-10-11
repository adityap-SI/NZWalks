using Microsoft.AspNetCore.Mvc;
using NZWalksUI.Models;
using System.Text;
using System.Text.Json;

namespace NZWalksUI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<RegionDto> regions = new List<RegionDto>();

            try
            {
                var client = httpClientFactory.CreateClient();

                var httpReponseMessage = await client.GetAsync("http://localhost:5289/api/regions");

                httpReponseMessage.EnsureSuccessStatusCode();

                regions.AddRange(await httpReponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());
                
                //ViewBag.stringResponseBody = stringResponseBody;
            }
            catch (Exception ex)
            {

                throw;
            }


            return View(regions);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddRegionDto model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:5289/api/Regions"),
                Content = new StringContent(JsonSerializer.Serialize(model),Encoding.UTF8, "application/json"),
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

            if(response != null)
            {
                return RedirectToAction("Index", "Regions");
            }
            return View();
        }
    }
}
