using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidéothèque.Models;
using PagedList;

namespace Vidéothèque.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        public ActionResult Index(string searchName, int? page, string sortOrder)
        {
            int pageSize = 12, pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            // Current movies
            var movies = _context.Movies.Include(m => m.MovieGenre).ToList();

            if (sortOrder != null)
            {
                if (sortOrder == "Year")
                    movies = _context.Movies.Include(m => m.MovieGenre).OrderBy(g => g.ReleaseDate).ToList();
                else if (sortOrder == "Title")
                    movies = _context.Movies.Include(m => m.MovieGenre).OrderBy(m => m.Title).ToList();
                else if (sortOrder == "Price")
                    movies = _context.Movies.Include(m => m.MovieGenre).OrderBy(m => m.Price).ToList();
            }

            // Filter down if necessary
            if (!String.IsNullOrEmpty(searchName))
            {
                if (_context.Movies.Where(m => m.Title.Contains(searchName)).ToList().Count != 0)
                    movies = _context.Movies.Where(m => m.Title.Contains(searchName)).ToList();
                else if (_context.Movies.Include(m => m.MovieGenre).Where(m => m.MovieGenre.Name.Contains(searchName)).ToList().Count != 0)
                    movies = _context.Movies.Include(m => m.MovieGenre).Where(m => m.MovieGenre.Name.Contains(searchName)).ToList();
                else
                {
                    movies = _context.Movies.Include(m => m.MovieGenre).Where(m => m.MovieGenre.Name.Contains(searchName)).ToList();
                    //no movies that containt the searched string
                }
            }

            IPagedList<Movie> paged_movies = movies.ToPagedList(pageIndex, pageSize);

            // Pass your list out to your view
            return View(paged_movies);
        }

        [AllowAnonymous]
        public ActionResult Details(int id, string searchName)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(m => m.Id == id);

            //List<ApplicationUser> users 

            if (searchName != null)
                return RedirectToAction("Index", "Home", new { searchName = searchName });
            return View(movie);
        }

        public ActionResult New()
        {
            ViewBag.Message = "Your application New page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}