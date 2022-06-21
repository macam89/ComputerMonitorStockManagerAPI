using Microsoft.AspNetCore.Mvc;


namespace ComputerMonitorStockManager.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
