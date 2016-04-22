namespace RankingsTable.UI.Controllers
{
    using Microsoft.AspNet.Mvc;

    internal class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
        
        public IActionResult Error()
        {
            return this.View();
        }
    }
}
