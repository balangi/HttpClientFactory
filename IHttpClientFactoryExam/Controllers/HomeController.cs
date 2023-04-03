using Microsoft.AspNetCore.Mvc;

namespace IHttpClientFactoryExam.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController( 
            ILogger<HomeController> logger,
            IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("Git");
            var result = await client.GetStringAsync("/");

            return Ok(result);
        }
    }
}