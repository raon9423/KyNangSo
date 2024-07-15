using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCore.Models;
using X.PagedList;

namespace WebAppCore.Controllers
{
    public class PageController : Controller
    {
        private readonly SqlwebchivalryContext _context;

        public PageController(SqlwebchivalryContext context)
        {
            _context = context;
        }
        public IActionResult Privacy(int page = 1)
        {
            var pages = _context.Pages.OrderByDescending(p => p.CreateAt)
                                      .ToPagedList(page, 10);

            return View(pages);
        }
    }
}