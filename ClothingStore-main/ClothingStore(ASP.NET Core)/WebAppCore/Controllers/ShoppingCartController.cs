using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCore.Models;
using WebAppCore.ModelViews;
using WebAppCore.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using X.PagedList;

namespace WebAppCore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly SqlwebchivalryContext _context;

        public ShoppingCartController(SqlwebchivalryContext context)
        {
            _context = context;
        }

        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang") ?? new List<CartItem>();
                return gh;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddToCart(int productID, int? amount)
        {
            List<CartItem> gioHang = GioHang;
            try
            {
                CartItem item = gioHang.SingleOrDefault(p => p.Product.ProductId == productID);
                if (item != null)
                {
                    item.Amount = amount ?? (item.Amount + 1);
                }
                else
                {
                    Product productToAdd = _context.Products.FirstOrDefault(p => p.ProductId == productID);
                    if (productToAdd != null)
                    {
                        item = new CartItem(productToAdd, amount ?? 1);
                        gioHang.Add(item);
                    }
                }

                HttpContext.Session.Set("GioHang", gioHang); 
                return RedirectToAction("Index", "Product"); 
            }
            catch
            {
                return RedirectToAction("Index", "Product"); 
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UpdateCart(int productId, int? amount)
        {
            try
            {
                var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (cart != null)
                {
                    CartItem item = cart.SingleOrDefault(p => p.Product.ProductId == productId);
                    if (item != null && amount.HasValue)
                    {
                        item.Amount = amount.Value;
                    }

                    HttpContext.Session.Set("GioHang", cart);

                    return Json(new { success = true, newTotal = cart.Sum(x => x.TotalMoney) });
                }
                return Json(new { success = false });
            }
            catch
            {
                return Json(new { success = false });
            }
        }


        public ActionResult RemoveFromCart(int productID)
        {
            List<CartItem> gioHang = GioHang;
            try
            {
                CartItem item = gioHang.SingleOrDefault(p => p.Product.ProductId == productID);

                if (item != null)
                {
                    gioHang.Remove(item);
                    HttpContext.Session.Set("GioHang", gioHang); 
                }

                return RedirectToAction("IndexCart", "ShoppingCart"); 
            }
            catch
            {
                return RedirectToAction("IndexCart", "ShoppingCart"); 
            }
        }
        public IActionResult PrivacyCart(int ? page)
        {
            
            List<CartItem> gioHang = GioHang; 

            int pageNumber = page ?? 1;
            int pageSize = 10; 

            IPagedList<CartItem> pagedGioHang = gioHang.ToPagedList(pageNumber, pageSize);
            return View(pagedGioHang);
        }

        [Route("Cart.html", Name = "Cart")]
        public IActionResult IndexCart(int? page)
        {
            List<CartItem> gioHang = GioHang;

            int pageNumber = page ?? 1;
            int pageSize = 10; 

            IPagedList<CartItem> pagedGioHang = gioHang.ToPagedList(pageNumber, pageSize);
            return View(pagedGioHang);
        }

    }
}