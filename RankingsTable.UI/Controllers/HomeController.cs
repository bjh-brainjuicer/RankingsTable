using Microsoft.AspNet.Mvc;

namespace RankingsTable.UI.Controllers
{
    using RankingsTable.Data;

    public class HomeController : Controller
    {
        private IRankingsTableDbContext dbContext;

        public HomeController(IRankingsTableDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
