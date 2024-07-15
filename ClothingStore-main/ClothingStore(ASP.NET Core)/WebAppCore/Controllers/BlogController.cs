using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCore.Models;
using X.PagedList;
using Microsoft.EntityFrameworkCore;


namespace WEBCHIVALRY.Controllers
{
    public class BlogController : Controller
    {
        private readonly SqlwebchivalryContext _context;

        public BlogController(SqlwebchivalryContext context)
        {
            _context = context;
        }
        public IActionResult IndexBlog(int page = 1)
        {
            var blogs = _context.Blogs.OrderByDescending(b => b.CreatedDate)
                                      .ToPagedList(page, 2);

            return View(blogs);
        }
        public IActionResult Privacy(int id)
        {
            var blog = _context.Blogs.AsNoTracking().FirstOrDefault(x => x.PostId == id);

            if (blog == null)
            {
                return RedirectToAction("Index");
            }

            return View(blog);
        }
    }

}