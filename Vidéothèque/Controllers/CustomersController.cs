using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidéothèque.Models;
using Vidéothèque.ViewModels;
using System.Data.Entity;

namespace Vidéothèque.Controllers
{
    [Authorize(Roles = RoleName.Admin)]

    public class CustomersController : Controller
    {
        // GET: Customers

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       
        public ActionResult Index()
        {
            var customers = _context.Users.ToList();
            return View(customers);
        }
        [HttpPost]
        public ActionResult Index(string searchName)
        {

            return RedirectToAction("Index", "Home", new { searchName = searchName });

        }
    }
}