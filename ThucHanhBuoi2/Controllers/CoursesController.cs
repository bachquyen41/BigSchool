using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThucHanhBuoi2.Models;

namespace ThucHanhBuoi2.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        
        public CoursesController ()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        public ActionResult Create()
        {
            var viewModel = new CoursesController
            {
                Categories = _dbContext.Categories.ToList();
            };
            return View(ViewModels);
        }
    }
}