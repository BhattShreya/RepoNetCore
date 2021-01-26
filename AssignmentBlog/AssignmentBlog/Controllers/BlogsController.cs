using AssignmentBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentBlog.Controllers
{
    //[Authorize]
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Blog Blog { get; set; }
        public BlogsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new {data = await _db.Blogs.ToListAsync()});
        }

        public IActionResult Addblog(int? id)
        {
            Blog = new Blog();
            if (id == null)
            {
                //create
                return View(Blog);
            }
            //update
            Blog = _db.Blogs.FirstOrDefault(u => u.ID == id);
            if (Blog == null)
            {
                return NotFound();
            }
            return View(Blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Addblog()
        {
            if (ModelState.IsValid)
            {
                if (Blog.ID == 0)
                {
                    //create
                    _db.Blogs.Add(Blog);
                }
                else
                {
                    _db.Blogs.Update(Blog);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Blog);

        }

    }
}
