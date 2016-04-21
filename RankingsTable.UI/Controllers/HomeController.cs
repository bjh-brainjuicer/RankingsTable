using Microsoft.AspNet.Mvc;

namespace RankingsTable.UI.Controllers
{
    using System.Linq;

    using Microsoft.Data.Entity;

    using RankingsTable.EF;

    public class HomeController : Controller
    {
        private IRankingsTableDbContext dbContext;

        public HomeController(IRankingsTableDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var players = this.dbContext.Players.Include(p => p.AwayFixtures).Include(p => p.HomeFixtures).ToList();
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
