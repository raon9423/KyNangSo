using X.PagedList;
using WebAppCore.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCore.Models;
using System;

namespace WebAppCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly SqlwebchivalryContext _context;

        public ProductController(SqlwebchivalryContext context)
        {
            _context = context;
        }
        [Route("Index")]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page.HasValue && page > 0 ? page.Value : 1;
                var pageSize = 5;

                var lsTinDangs = _context.Products.AsNoTracking()
                    .OrderByDescending(x => x.DateCreated);

                var models = new PagedList<Product>(lsTinDangs, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;

                return View("Index", models);
            }
            catch
            {
                return RedirectToAction("Index, Home");
            }
        }
      
        [Route("/{Alias}", Name = "List")]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var danhmuc = _context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);

                if (danhmuc == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                var lsTinDangs = _context.Products
                    .AsNoTracking()
                    .Where(x => x.CatId == danhmuc.CatId)
                    .OrderByDescending(x => x.DateCreated);

                var models = new PagedList<Product>(lsTinDangs, page, pageSize);

                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
        [Route("/{Alias}-{id}", Name = "Privacyc")]
        public IActionResult Privacy(int id, string Alias)
        {
            try
            {
                var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.ProductId == id && x.Alias == Alias);

                if (product == null)
                {
                    return RedirectToAction("List", new { Alias = Alias });
                }

                var lsProducts = _context.Products.AsNoTracking()
                    .Where(x => x.CatId == product.CatId && x.ProductId != id  && x.Active == true)
                    .OrderByDescending(x=>x.DateCreated).Take(4).ToList();
                ViewBag.SanPham = lsProducts;
                return View(product);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

    }
}