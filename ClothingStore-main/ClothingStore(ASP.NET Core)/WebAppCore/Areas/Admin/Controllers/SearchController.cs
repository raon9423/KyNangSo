using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppCore.Models;

namespace WebAppCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("AdminSearch")]
    [Route("Admin/AdminSearchAdmin")]
    public class SearchController : Controller
    {
        private readonly SqlwebchivalryContext _context;

        public SearchController(SqlwebchivalryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
            try
            {
                List<Product> productList = new List<Product>();

                if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
                {
                    // Log a message when the keyword is empty
                    Console.WriteLine("Empty keyword received in FindProduct action.");
                    return PartialView("ListProductSearchPartia", null);
                }

                productList = _context.Products
                    .AsNoTracking()
                    .Where(p => p.ProductName.Contains(keyword))
                    .ToList();

                // Log the number of products found
                Console.WriteLine($"Found {productList.Count} products matching the keyword: {keyword}");

                return PartialView("ListProductSearchPartial", productList);
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the search
                Console.WriteLine($"Exception in FindProduct action: {ex.Message}");
                return PartialView("ErrorPartial"); // You can create an ErrorPartial view
            }
        }
    }
}
