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

        /*public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.MovieGenre).ToList();

            return View(movies);
        }
        */
        public ActionResult Index(string searchName, int? page)
        {
            int pageSize = 12, pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            // Current movies
            var movies = _context.Movies.Include(m => m.MovieGenre).ToList();

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

        /*public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }
        */

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