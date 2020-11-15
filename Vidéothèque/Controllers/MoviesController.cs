using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Vidéothèque.Models;
using Vidéothèque.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidéothèque.Controllers
{
    [Authorize(Roles = RoleName.Admin)]

    public class MoviesController : Controller
    {
        // GET: Movies

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Random()
        {
            var movie = new Movie() { Title = "Shrek" };

            /*var viewResult = new ViewResult();
            _ = viewResult.ViewData.Model;*/

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"},
                new Customer { Name = "Customer 3"}


            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
       
        //[AllowAnonymous]
        public ActionResult Index()
        {

            //var movies = _context.Movies.Include(m => m.MovieGenre).ToList();
            //return View(movies);
            return View();

        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(cust => cust.Id == id);

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        public ActionResult MovieForm()
        {

            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (movie.Id == 0) //the customer does not exist on the DB which means it's a new Customer
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Include(m => m.MovieGenre).Single(c => c.Id == movie.Id);

                //AutoMapper
                // Mapper.Map(customer, customerInDb);
                movieInDb.Title = movie.Title;
                movieInDb.NumberInStock = (int)movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
            }

            try
            {
                _context.SaveChanges();

            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Movies");
        }


    }
}
