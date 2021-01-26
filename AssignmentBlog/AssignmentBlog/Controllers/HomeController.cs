using AssignmentBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentBlog.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public User User { get; set; }
       
        public IActionResult Index()
        {
            return View();
        }

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult CheckUser(User userobj)
        {
            User = new User();

            User = _db.Users.FirstOrDefault(u => u.AuthorName == userobj.AuthorName && u.Password == userobj.Password);
            if ( User != null)
            {
                return RedirectToAction("Index","Blogs");
            }
            else
            {
                return RedirectToAction("Index");
            }


        }

    }
}
