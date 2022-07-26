using Microsoft.AspNetCore.Mvc;


namespace ComputerMonitorStockManager.Controllers
{
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
