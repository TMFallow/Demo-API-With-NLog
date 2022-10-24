using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_Gateway_With_Ocelot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index View Called Successfully");
            return View();
        }
    }
}
