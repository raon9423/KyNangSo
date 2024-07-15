using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAppCore.Models;
using WebAppCore.ModelViews;
using X.PagedList;

namespace WebAppCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SqlwebchivalryContext _context;

        public HomeController(ILogger<HomeController> logger, SqlwebchivalryContext db)
        {
            _logger = logger;
            _context = db;
        }
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            var allProducts = _context.Products.AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .ToList();

            // Select 4 random products
            var randomProducts = allProducts.OrderBy(x => Guid.NewGuid()).Take(4).ToList();

            model.Products = new List<ProductViewModel>
    {
        new ProductViewModel { category = null, lsTinDangs = allProducts },
    };

            ViewBag.AllProducts = allProducts;
            ViewBag.RandomProducts = randomProducts;

            return View(model);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
